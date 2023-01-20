using API.Modules.Auth.Endpoints;
using API.Modules.Auth.Ressources;
using API.Modules.Auth.Validators;
using DAL;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace API.Modules.Auth;

public static class AuthModule
{
    public static WebApplicationBuilder RegisterAuthModule(this WebApplicationBuilder builder)
    {
        var ddd = builder.Configuration.GetSection("JWTSETTINGS");


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
           .SetIsOriginAllowedToAllowWildcardSubdomains()
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
            .ProducesProblem(StatusCodes.Status500InternalServerError);


        auth.MapPost("signup", SignupEndpoint.signup)
            .Produces<SignupResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .AllowAnonymous();

        auth.MapPost("username", UsernameEndpoint.username)
            .Produces<AvailableUsernameRequest>()
            .AllowAnonymous();

        auth.MapPost("signin", SigninEndpoint.signin)
            .Produces<SigninRessponse>()
            .ProducesProblem(StatusCodes.Status409Conflict)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .AllowAnonymous();

        auth.MapPost("signout", SignoutEndpoint.signout)
            .Produces(StatusCodes.Status204NoContent)
            .RequireAuthorization("customer")
            .RequireAuthorization("admin");

        auth.MapGet("checkauth", CheckauthEndpoint.checkAuth)
            .Produces<SignedinResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithOpenApi()
            .AllowAnonymous();

        auth.MapPost("Roles", CreateRoleEndpoint.CreateRole)
            .Produces(StatusCodes.Status200OK)
            .ProducesValidationProblem();

        return auth;
    }
}
