# 🎨 Decorator Pattern in .NET  

This repository provides an in-depth implementation of the **Decorator Pattern** in **.NET C#**. The Decorator Pattern is a structural design pattern that allows behavior to be added to an individual object dynamically, without affecting the behavior of other objects of the same class.  

In this project, you'll explore:  
- Manual and **Scrutor**-based service registration for decorators.  
- Practical examples including **logging** and **in-memory operations**.  
- Clean and maintainable code adhering to **OOP principles**.  

## 🌟 Features  

### Core Concepts  
- **Decorator Pattern**: Dynamically add functionality to objects without altering their structure.  
- **Manual and Scrutor-based Registration**: Learn two approaches for setting up decorators in .NET.  
- **Practical Use Cases**: Logging, caching, and in-memory operations.  

### Tools and Libraries  
- **Scrutor**: A library for assembly scanning and automatic decorator registration in .NET.  
- **Dependency Injection (DI)**: Utilize .NET’s built-in DI container to manage service lifetimes and decorators.  

## 📂 Repository Structure  

```
📦 src  
 ┣ 📂 DecoratorPattern             # Core implementation of the pattern  
 ┣ 📂 WithoutDecoratorPattern      # Core implementation without pattern  
```  

## 🛠 Getting Started  

### Prerequisites  
Ensure you have the following installed:  
- .NET Core SDK  
- A modern C# IDE (e.g., Visual Studio or JetBrains Rider)  

### Step 1: Clone the Repository  
```bash  
git clone https://github.com/MrEshboboyev/decorator-pattern.git  
cd decorator-pattern  
```  

### Step 2: Run the Project  
```bash  
dotnet run --project src/DecoratorPattern  
```  

### Step 3: Explore the Code  
Navigate through the codebase to see the decorator pattern in action with logging, caching, and service registrations.  

## 📖 Code Highlights  

### Manual Registration Example  
```csharp  
services.AddTransient<IService, Service>();  
services.AddTransient<IService>(provider =>  
{  
    var original = provider.GetRequiredService<Service>();  
    return new LoggingDecorator(original);  
});  
```  

### Scrutor-Based Registration Example  
```csharp  
services.Scan(scan => scan  
    .FromAssemblyOf<Service>()  
    .AddClasses(classes => classes.AssignableTo<IService>())  
    .AsImplementedInterfaces()  
    .WithTransientLifetime()  
    .Decorate<IService, LoggingDecorator>());  
```  

### Decorator Example: Logging  
```csharp  
public class LoggingDecorator : IService  
{  
    private readonly IService _innerService;  

    public LoggingDecorator(IService innerService)  
    {  
        _innerService = innerService;  
    }  

    public void PerformOperation()  
    {  
        Console.WriteLine("Logging: Before operation.");  
        _innerService.PerformOperation();  
        Console.WriteLine("Logging: After operation.");  
    }  
}  
```  

## 🌐 Use Cases  

### 1. Logging Decorator  
Logs messages before and after an operation is performed.  

### 2. Caching Decorator  
Stores results of expensive operations in memory for faster subsequent access.  

### 3. In-Memory Data Processing  
Demonstrates in-memory operations to showcase how decorators can extend functionality dynamically.  


## 🌟 Why This Project?  
1. **Learn Design Patterns**: Understand the practical use of the decorator pattern in modern software.  
2. **Clean and Extensible Code**: Build solutions that adhere to OOP principles and are easy to extend.  
3. **Real-World Examples**: Explore logging and caching as practical applications of decorators.  
4. **Modern Tools**: Learn how to leverage **Scrutor** for simplified registration.  

## 🏗 About the Author  
This project was developed by [MrEshboboyev](https://github.com/MrEshboboyev), a software developer passionate about clean code, design patterns, and scalable architectures.  

## 📄 License  
This project is licensed under the MIT License. Use it to enhance your projects or learn more about design patterns in .NET.  

## 🔖 Tags  
C#, .NET, Decorator Pattern, Design Patterns, Scrutor, Dependency Injection, Logging, In-Memory, Software Architecture, OOP, Clean Code  

---  

Feel free to suggest new features, raise issues, or fork the project to contribute! 🚀  
