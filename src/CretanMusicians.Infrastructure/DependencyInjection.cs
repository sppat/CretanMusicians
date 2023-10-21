using CretanMusicians.Application;
using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Infrastructure.DatabaseContext;
using CretanMusicians.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CretanMusicians.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("Default"));
            options.UseSnakeCaseNamingConvention();
        });
        services.AddScoped<IMusicianRepository, MusicianRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        
        return services;
    }
}