using System.Text;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Services.Authentication.Command.Application.Common.Interfaces.Services;
using BuberDinner.Application.Services.Authentication.Command.Infratrasture.Authentication;
using BuberDinner.Application.Services.Authentication.Command.Infratrasture.Services;
using BuberDinner.Infratrasture.Persistance;
using BuberDinner.Infratrasture.Persistance.Repositories;
using BuberDinner.Infratrasture.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BuberDinner.Infratrasture;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastracture(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddAuth(configuration);
        services.AddPersistance();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        return services;
    }
    
    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<BuberDinnerDbContext>(options => options.UseSqlServer());
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName,jwtSettings);
        
        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings.Issuer,
                ValidAudience = jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.Secret)),
            });

        return services;
    }
}