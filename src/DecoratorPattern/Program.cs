using DecoratorPattern;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<IAsyncPolicy>(serviceProvider =>
{
    // Configure a retry policy that retries 3 times with exponential backoff
    return Policy.Handle<HttpRequestException>()
        .WaitAndRetryAsync(3, retryAttempt 
            => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
});


// builder.Services.AddDecoratorsManually();
builder.Services.AddDecoratorsWithScrutor();
builder.Services.AddMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();