using Microsoft.Extensions.Caching.Memory;

namespace CacheDemo;

public class CacheClient
{
    public static IMemoryCache Current = new MemoryCache(new MemoryCacheOptions());
}