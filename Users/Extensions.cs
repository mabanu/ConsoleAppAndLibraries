using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Users.Repositories;

namespace Users;

public static class Extensions
{
    public static IServiceCollection AddUserModule(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }

    public static IApplicationBuilder UseUserModule(this IApplicationBuilder app)
    {
        return app;
    }
}