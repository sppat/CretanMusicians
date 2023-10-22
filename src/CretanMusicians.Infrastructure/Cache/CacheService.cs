using CretanMusicians.Application.Contracts.Cache;
using CretanMusicians.Domain.Exceptions;
using Microsoft.Extensions.Caching.Memory;

namespace CretanMusicians.Infrastructure.Cache;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _memoryCache;

    public CacheService(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public object? GetData(string key)
    {
        try
        {
            _memoryCache.TryGetValue(key, out var data);

            return data;
        }
        catch (Exception ex)
        {
            return default;
        }
    }

    public bool CacheData(string key, object data, TimeSpan expirationTime)
    {
        try
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.Add(TimeSpan.FromMinutes(10)),
                SlidingExpiration = expirationTime
            };

            _memoryCache.Set(key, data, cacheEntryOptions);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool RemoveData(string key)
    {
        try
        {
            _memoryCache.Remove(key);

            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}