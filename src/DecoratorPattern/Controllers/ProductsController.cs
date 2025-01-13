using DecoratorPattern.Domain;
using DecoratorPattern.Services.Abstraction;
using Microsoft.AspNetCore.Mvc;
using Polly;

namespace DecoratorPattern.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController(IProductService productService) : ControllerBase
{
    [HttpGet("{productId:int}")]
    public async Task<IActionResult> GetProduct(int productId)
    {
        var product = await productService.GetProduct(productId);
        
        return Ok(product);
    }
}