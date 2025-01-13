using Microsoft.Extensions.Caching.Memory;
using Polly;
using WithoutDecoratorPattern.Domain;
using WithoutDecoratorPattern.Services.Abstraction;

namespace WithoutDecoratorPattern.Services;

public class ProductService(IMemoryCache cache) : IProductService
{
    private readonly IMemoryCache _cache = cache;
    private readonly Random _random = new();

    public async Task<Product?> GetProduct(int id)
    {
        // 1. Logging logic
        Console.WriteLine($"Requesting product with ID: {id}");

        // 2. Caching logic
        if (_cache.TryGetValue(id, out Product? cachedProduct))
        {
            Console.WriteLine($"Cache hit for product with ID: {id}");
            return cachedProduct;
        }

        // 3. Retry logic using Polly
        var retryPolicy = Policy
            .Handle<Exception>()
            .RetryAsync(3, (exception, retryCount) =>
            {
                Console.WriteLine($"Retrying... Attempt {retryCount}");
            });

        var product = await retryPolicy.ExecuteAsync(async () =>
        {
            // Simulating a transient error with a 50% chance of success
            if (_random.Next(2) == 0)
            {
                throw new Exception("Transient error occurred!");
            }

            // Simulate fetching product data
            await Task.Delay(100); // Simulate delay

            Console.WriteLine($"Fetching product from database for ID: {id}");
            return new Product { Id = 1, Name = "Test" };
        });

        // Store the result in the cache
        _cache.Set(id, product, TimeSpan.FromMinutes(5));

        Console.WriteLine($"Product ID: {id} cached successfully.");

        return product;
    }
}