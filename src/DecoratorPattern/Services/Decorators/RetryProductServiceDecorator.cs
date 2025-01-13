using DecoratorPattern.Domain;
using DecoratorPattern.Services.Abstraction;
using Polly;

namespace DecoratorPattern.Services.Decorators;

public class RetryProductServiceDecorator(
    IProductService inner,
    IAsyncPolicy retryPolicy) : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        return await retryPolicy.ExecuteAsync(() => inner.GetProduct(id));
    }
}

