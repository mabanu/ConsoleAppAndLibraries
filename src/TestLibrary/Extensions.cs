using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TestLibrary.Repositories;

namespace TestLibrary;

public static class Extensions
{
    public static IServiceCollection AddTestLibrary(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ITestRepository, TestRepository>();

        return services;
    }

    public static IApplicationBuilder UseTestLibrary(this IApplicationBuilder app)
    {
        return app;
    }
}