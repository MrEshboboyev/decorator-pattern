using DecoratorPattern.Domain;

namespace DecoratorPattern.Services.Abstraction;

public interface IProductService
{
    Task<Product?> GetProduct(int id);
}