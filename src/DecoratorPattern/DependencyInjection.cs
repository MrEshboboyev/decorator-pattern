using DecoratorPattern.Services;
using DecoratorPattern.Services.Abstraction;
using DecoratorPattern.Services.Decorators;
using Microsoft.Extensions.Caching.Memory;
using Polly;

namespace DecoratorPattern;

public static class DependencyInjection
{
    public static IServiceCollection AddDecoratorsManually(this IServiceCollection services)
    {
        services.AddTransient<ProductService>();

        services.AddTransient<IProductService>(serviceProvider =>
        {
            var productService = serviceProvider.GetRequiredService<ProductService>();
            var retryPolicy = serviceProvider.GetRequiredService<IAsyncPolicy>();
            var cacheMemory = serviceProvider.GetRequiredService<IMemoryCache>();
            var logging = serviceProvider.GetRequiredService<ILogger<LoggingProductServiceDecorator>>();

            var retryDecorator = new RetryProductServiceDecorator(productService, retryPolicy);
            var cachingDecorator = new CachingProductServiceDecorator(retryDecorator, cacheMemory);
            var loggingDecorator = new LoggingProductServiceDecorator(cachingDecorator, logging);

            return loggingDecorator;
        });

        return services;
    }

    // It keeps your code clean and modular by separating concerns.
    // It allows you to extend functionality dynamically without touching the core logic.
    // It supports the Open/Closed Principle, making your code easier to maintain and scale.
    public static IServiceCollection AddDecoratorsWithScrutor(this IServiceCollection services)
    {
        services.AddTransient<IProductService, ProductService>();

        services.Decorate<IProductService, RetryProductServiceDecorator>();
        services.Decorate<IProductService, CachingProductServiceDecorator>();
        services.Decorate<IProductService, LoggingProductServiceDecorator>();

        return services;
    }
}