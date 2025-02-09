using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Project.Application.Behaviours;
using Project.Application.Features.Project.Commands;

namespace Project.Application;

public static class ApplicationRegisteration
{
    public static IServiceCollection AddApplicationRegisteration(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        //services.AddControllers().AddFluentValidation(config => config.RegisterValidatorsFromAssembly(typeof(GetAllOrderValidation).Assembly));
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(CreateProjectCommand).Assembly));

        return services;
    }
}
