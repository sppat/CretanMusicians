using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CretanMusicians.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(
            configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        
        return services;
    }
}