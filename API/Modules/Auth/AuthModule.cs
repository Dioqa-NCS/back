﻿using API.Modules.Auth.Endpoints;
using API.Modules.Auth.Ressources;
using API.Modules.Auth.Validators;
using DAL;
using DAL.Modules.Comptes;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth;

public static class AuthModule
{
    public static WebApplicationBuilder RegisterAuthModule(this WebApplicationBuilder builder)
    {
        builder.Services.AddIdentity<Compte, IdentityRole<int>>()
            .AddDefaultTokenProviders()
            .AddUserManager<UserManager<Compte>>()
            .AddSignInManager<SignInManager<Compte>>()
            .AddEntityFrameworkStores<NCSContext>();

        builder.Services
            .AddAuthorization()
            .AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.Domain = "https://ncs-front.netlify.app/";
                options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Environment.GetEnvironmentVariable("COOKIE_EXPIRY")));
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            });

        builder.Services
            .AddAuthorizationBuilder()
            .AddPolicy(AuthPolicies.Admin, policy =>
                   policy
                        .RequireRole(AuthRole.Admin))
            .AddPolicy(AuthPolicies.Customer, policy => 
                   policy
                        .RequireRole(AuthRole.Customer));

        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddValidatorsFromAssemblyContaining<SignupRequestValidator>(ServiceLifetime.Transient);


        builder.Services.AddCors(options => options.AddPolicy(name: AuthPolicies.CORS,
        policy => policy
           .WithOrigins(Environment.GetEnvironmentVariable("CORS_DOMAINS"))
           .SetIsOriginAllowed(origin => true)
           .AllowAnyHeader()
           .AllowCredentials()
           .WithMethods("GET", "PATCH", "POST", "DELETE", "OPTIONS")
           .SetPreflightMaxAge(TimeSpan.FromSeconds(3600))
           ));

        return builder;
    }




    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var auth = endpoints
            .MapGroup("Auth")
            .RequireCors(AuthPolicies.CORS)
            .WithOpenApi()
            .WithTags("Auth")
            .RequireAuthorization(AuthPolicies.Admin);


        auth.MapPost("Compte/{userEmail}/Role", AddRoleToUserEndpoint.addRoleToUser)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription(AddRoleToUserEndpoint.Description);


        auth.MapPost("signup", SignupEndpoint.signup)
            .Produces<SignupResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithDescription(SignupEndpoint.Description)
            .AllowAnonymous();

        auth.MapPost("username", UsernameEndpoint.username)
            .Produces<AvailableUsernameRequest>()
            .WithDescription(UsernameEndpoint.Description)
            .AllowAnonymous();

        auth.MapPost("signin", SigninEndpoint.signin)
            .Produces<SigninRessponse>()
            .ProducesProblem(StatusCodes.Status409Conflict)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .WithDescription(SigninEndpoint.Description)
            .AllowAnonymous();

        auth.MapPost("signout", SignoutEndpoint.signout)
            .Produces(StatusCodes.Status204NoContent)
            .WithDescription(SignoutEndpoint.Description)
            .RequireAuthorization(AuthPolicies.Customer)
            .RequireAuthorization(AuthPolicies.Admin);

        auth.MapGet("checkauth", CheckauthEndpoint.checkAuth)
            .Produces<SignedinResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription(CheckauthEndpoint.Description)
            .AllowAnonymous();

        auth.MapPost("Roles", CreateRoleEndpoint.CreateRole)
            .Produces(StatusCodes.Status200OK)
            .WithDescription(CreateRoleEndpoint.Description)
            .ProducesValidationProblem();

        return auth;
    }
}
