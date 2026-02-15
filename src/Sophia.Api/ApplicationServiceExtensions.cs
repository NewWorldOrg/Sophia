namespace Sophia.Api;

using System.Reflection;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Sophia.Api.Converters;
using Sophia.Infrastructure;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
    }

    public static WebApplicationBuilder AddApplicationBuilder(
        this WebApplicationBuilder builder
    )
    {
        var configuration = builder.Configuration;

        builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.Converters.Add(new JstDateTimeConverter());
            });

        builder.Services.AddApplicationServices();

        builder.Services.AddSwaggerGen(options =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            options.IncludeXmlComments(xmlPath);
        });

        builder.Services.AddRepository();

        // Authentication
        var auth0Domain = configuration["Auth0:Domain"]!;
        var auth0ClientId = configuration["Auth0:ClientId"]!;
        var auth0ClientSecret = configuration["Auth0:ClientSecret"]!;

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie(options =>
        {
            options.Cookie.SameSite = SameSiteMode.None;
            options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            options.Cookie.HttpOnly = true;
        })
        .AddOpenIdConnect(options =>
        {
            options.Authority = $"https://{auth0Domain}";
            options.ClientId = auth0ClientId;
            options.ClientSecret = auth0ClientSecret;
            options.ResponseType = OpenIdConnectResponseType.Code;
            options.CallbackPath = "/auth0/callback";
            options.Scope.Clear();
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");
            options.SaveTokens = true;
        });

        // CORS
        var graceOrigin = configuration["Grace:Origin"]!;

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithOrigins(graceOrigin)
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });

        return builder;
    }
}
