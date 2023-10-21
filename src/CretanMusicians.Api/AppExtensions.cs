using CretanMusicians.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.Api;

public static class AppExtensions
{
    public static async Task<WebApplication> MigrateAsync(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await context.Database.MigrateAsync();

        return app;
    }
}