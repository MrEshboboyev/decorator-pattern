using DecoratorPattern.Domain;
using DecoratorPattern.Services.Abstraction;
using Microsoft.Extensions.Caching.Memory;

namespace DecoratorPattern.Services.Decorators;

public class CachingProductServiceDecorator(
    IProductService inner,
    IMemoryCache cache) : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        // Attempt to retrieve the product from the cache
        if (cache.TryGetValue(id, out Product cachedProduct))
        {
            Console.WriteLine($"Cache hit for product with ID: {id}");
            return cachedProduct;
        }

        // If not found in the cache, retrieve it from the inner service
        var product = await inner.GetProduct(id);
        cache.Set(id, product);

        return product;
    }
}
