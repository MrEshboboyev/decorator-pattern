using DecoratorPattern.Domain;
using DecoratorPattern.Services.Abstraction;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace DecoratorPattern.Services;

public class ProductService(IMemoryCache cache) : IProductService
{
    private readonly IMemoryCache _cache = cache;
    private readonly Random _random = new();

    public async Task<Product> GetProduct(int id)
    {
        Console.WriteLine("Retrieving product from database...");
     
        return new Product { Id = id, Name = "Sample Product" };
    }
}