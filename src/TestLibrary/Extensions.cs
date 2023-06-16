using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TestLibrary.Repositories;

namespace TestLibrary;

public static class Extensions
{
    public static IServiceCollection AddTestModule(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ITestRepository, TestRepository>();

        return services;
    }

    public static IApplicationBuilder UseTestModule(this IApplicationBuilder app)
    {
        return app;
    }
}