using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using CretanMusicians.Application.Contracts.Cache;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace CretanMusicians.Api.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class CacheAttribute : Attribute, IAsyncActionFilter
{
    public int LifeTimeInMinutes { get; init; }
    public string? RouteParameterName { get; init; }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var cacheService = context.HttpContext.RequestServices.GetRequiredService<ICacheService>();
        var cacheKey = GenerateCacheKey(context.HttpContext);
        var cacheResponse = cacheService.GetData(cacheKey);

        if (cacheResponse is not null)
        {
            var contentResult = new ContentResult
            {
                Content = JsonSerializer.Serialize(cacheResponse),
                ContentType = "application/json",
                StatusCode = StatusCodes.Status200OK
            };

            context.Result = contentResult;

            return;
        }

        var action = await next();

        if (action.Result is OkObjectResult okObjectResult)
        {
            cacheService.CacheData(cacheKey, okObjectResult.Value!, TimeSpan.FromMinutes(LifeTimeInMinutes));
        }
    }

    private string GenerateCacheKey(HttpContext context)
    {
        var keyBuilder = new StringBuilder();

        return GenerateKeyForGetOne(keyBuilder, context) ?? GenerateKeyForGetMany(keyBuilder, context.Request);
    }

    private string? GenerateKeyForGetOne(StringBuilder keyBuilder, HttpContext context)
    {
        if (RouteParameterName is null) return default;

        var routeData = context.GetRouteData();
        var parameter = routeData.Values[RouteParameterName];

        keyBuilder.Append(parameter);

        return keyBuilder.ToString();
    }

    private static string GenerateKeyForGetMany(StringBuilder keyBuilder, HttpRequest request)
    {
        keyBuilder.Append($"GET");

        foreach (var (queryParam, value) in request.Query.OrderBy(p => p.Key))
        {
            keyBuilder.Append($"/{queryParam}-{value}");
        }

        return keyBuilder.ToString();
    }
}