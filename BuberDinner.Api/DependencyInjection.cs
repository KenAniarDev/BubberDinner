using BuberDinner.Api.Commons.Mapping;
using BuberDinner.Application.Services.Authentication.Command.Api.Commons.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;

namespace BuberDinner.Application.Services.Authentication.Command.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddMappings();
        
        // Error Handling Via Filters
        // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        services.AddControllers();
        // Error Handling Via Custom ProblemDetailsFactory and error endpoint
        services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(option =>
        {
            option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
            option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter a valid token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "Bearer"
            });
            option.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        });
        
        return services;
    }
}