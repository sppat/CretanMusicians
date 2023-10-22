using CretanMusicians.Api;
using CretanMusicians.Application.Contracts.Cache;
using CretanMusicians.Infrastructure;
using CretanMusicians.Infrastructure.Cache;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
{
    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddMemoryCache();
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddSingleton<ICacheService, CacheService>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseExceptionHandler("/error");
    
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
}

await app.MigrateAsync();
app.Run();
