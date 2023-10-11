using CretanMusicians.Application;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CretanMusicians.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddApplication();
        services.AddScoped<IMusicianRepository, MusicianRepository>();
        
        return services;
    }
}