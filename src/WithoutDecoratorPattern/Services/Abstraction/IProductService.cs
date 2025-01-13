using WithoutDecoratorPattern.Domain;

namespace WithoutDecoratorPattern.Services.Abstraction;

public interface IProductService
{
    Task<Product?> GetProduct(int id);
}