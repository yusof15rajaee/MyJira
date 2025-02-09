using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Domain.Repositories;
using Project.Infrastructure.Persistence;
using Project.Infrastructure.Persistence.Repositories;

namespace Project.Infrastructure;

public static class InfrastructureRegisteration
{
    public static IServiceCollection AddInfrastructureRegisteration(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ProjectDbContext>(config => config.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IProjectRepository, ProjectRepository>();
        return services;
    }
}
