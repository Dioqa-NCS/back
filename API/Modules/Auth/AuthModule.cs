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
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromDays(int.Parse(Environment.GetEnvironmentVariable("COOKIE_EXPIRY")));
                options.SlidingExpiration = true;
                options.Cookie.Path = "/";
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
                        .RequireRole(AuthRole.Customer))
            .AddPolicy(AuthPolicies.AllRoles, policy => 
                   policy
                        .RequireRole(AuthRole.Admin, AuthRole.Customer)) ;

        builder.Services.AddTransient<IAuthService, AuthService>();
        builder.Services.AddValidatorsFromAssemblyContaining<SignupRequestValidator>(ServiceLifetime.Transient);


        builder.Services.AddCors(options => options.AddPolicy(name: AuthPolicies.CORS,
        policy => policy
           .WithOrigins(Environment.GetEnvironmentVariable("CORS_DOMAINS"))
           .WithMethods("GET", "PATCH", "POST", "DELETE", "OPTIONS")
           .AllowAnyHeader()
           .AllowCredentials()
           ));

        return builder;
    }




    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder endpoints)
    {

        var auth = endpoints
            .MapGroup("Auth")
            .RequireCors(AuthPolicies.CORS)
            .WithOpenApi()
            .WithTags("Auth");

        var authAdmin = auth.RequireAuthorization(AuthPolicies.Admin);

        var authCustomer = auth.RequireAuthorization(AuthPolicies.Customer);

        var authAllRoles = auth.RequireAuthorization(AuthPolicies.AllRoles);

        var authAnonymous = auth.AllowAnonymous();


        authAdmin.MapPost("Compte/{userName}/Role", AddRoleToUserEndpoint.addRoleToUser)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription(AddRoleToUserEndpoint.Description);

        authAdmin.MapPost("Roles", CreateRoleEndpoint.CreateRole)
            .Produces(StatusCodes.Status200OK)
            .WithDescription(CreateRoleEndpoint.Description)
            .ProducesValidationProblem();

        authAnonymous.MapPost("signup", SignupEndpoint.Signup)
            .Produces<SignupResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem()
            .WithDescription(SignupEndpoint.Description);


        authAnonymous.MapPost("username", UsernameEndpoint.Username)
            .Produces<AvailableUsernameRequest>()
            .WithDescription(UsernameEndpoint.Description);


        authAnonymous.MapPost("signin", SigninEndpoint.Signin)
            .Produces<SigninRessponse>()
            .ProducesProblem(StatusCodes.Status409Conflict)
            .ProducesProblem(StatusCodes.Status401Unauthorized)
            .WithDescription(SigninEndpoint.Description);

        authAnonymous.MapGet("checkauth", CheckauthEndpoint.CheckAuth)
            .Produces<SignedinResponse>()
            .ProducesProblem(StatusCodes.Status500InternalServerError)
            .WithDescription(CheckauthEndpoint.Description)
            .AllowAnonymous();

        authAllRoles.MapPost("signout", SignoutEndpoint.Signout)
            .Produces(StatusCodes.Status204NoContent)
            .WithDescription(SignoutEndpoint.Description)
            .RequireAuthorization(AuthPolicies.AllRoles);


        return auth;
    }
}
