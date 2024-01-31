
using BuberDinner.Application;
using BuberDinner.Application.Services.Authentication.Command.Api;
using BuberDinner.Application.Services.Authentication.Command.Infratrasture;
using BuberDinner.Infratrasture;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastracture(builder.Configuration);
}

var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    // Error Handling Via Middleware
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    
    // Error Handling Via Custom ProblemDetailsFactory and error endpoint
    app.UseExceptionHandler("/error");
    // using minimal apis
    // app.Map("/error", (HttpContext httpContext) =>
    // {
    //     Exception? exception = httpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
    //
    //     return Results.Problem(title: exception?.Message);
    // });
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();
    app.Run();
}
