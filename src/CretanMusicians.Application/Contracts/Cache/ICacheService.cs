namespace CretanMusicians.Application.Contracts.Cache;

public interface ICacheService
{
    object? GetData(string key);
    bool CacheData(string key, object data, TimeSpan expirationTime);
    bool RemoveData(string key);
}