using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Repositories;
using Project.Infrastructure.Persistence.Repositories;

namespace Project.Infrastructure;

public static class InfrastructureRegisteration
{
    public static IServiceCollection AddInfrastructureRegisteration(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProjectRepository, ProjectRepository>();

        return services;
    }
}
