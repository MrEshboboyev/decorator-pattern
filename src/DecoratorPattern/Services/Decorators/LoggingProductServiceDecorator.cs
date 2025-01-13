using DecoratorPattern.Domain;
using DecoratorPattern.Services.Abstraction;

namespace DecoratorPattern.Services.Decorators;

public class LoggingProductServiceDecorator(
    IProductService inner,
    ILogger<LoggingProductServiceDecorator> logger)
    : IProductService
{
    public async Task<Product> GetProduct(int id)
    {
        logger.LogInformation($"Getting product with Id {id}");

        var product = await inner.GetProduct(id);

        logger.LogInformation($"Retrieved product: {product.Name}");

        return product;
    }
}
