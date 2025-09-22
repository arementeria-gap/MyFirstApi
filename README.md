# MyFirstApi

A modern ASP.NET Core Web API demonstrating best practices in service lifecycles, dependency injection, and design patterns.

## Features
- Product management with in-memory database
- Service lifecycles: Transient, Scoped, Singleton
- Strategy and Factory patterns for shipping cost calculation
- RESTful controllers for products, weather, and lifecycles
- Extensible architecture for shipping providers
- OpenAPI (Swagger) documentation

## Technologies
- ASP.NET Core
- Entity Framework Core (InMemory)
- Dependency Injection
- C#

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/) (recommended)
- C# Dev Kit extension for VS Code

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/arementeria-gap/MyFirstApi.git
   cd MyFirstApi
   ```
2. Restore dependencies:
   ```bash
   dotnet restore
   ```
3. Run the application:
   ```bash
   dotnet run --project MyFirstApi/MyFirstApi.csproj
   ```
4. Open [http://localhost:5000/swagger](http://localhost:5000/swagger) for API documentation.

5. To run tests `dotnet test --collect:"XPlat Code Coverage"`

## Project Structure
```
Controllers/         # API controllers
Data/                # DbContext and database initializer
Factories/           # Factory pattern implementations
Models/              # Data models
Services/            # Business logic services
Strategies/          # Strategy pattern for shipping
Program.cs           # App entry point and DI setup
```

## Service Lifecycles
- **Transient:** New instance every injection (e.g., `LifecyclesSupportService`)
- **Scoped:** One instance per HTTP request (e.g., `ProductService`, `LifecyclesService`)
- **Singleton:** One instance for the app lifetime (e.g., `ShippingCostStrategyFactory`)

## Design Patterns Used
- **Strategy Pattern:** For shipping cost calculation
- **Factory Pattern:** For creating shipping strategies/providers

## API Endpoints
- `/products` — Manage products
- `/weatherforecast` — Get weather data
- `/lifecycles` — Demonstrate service lifecycles

## Contributing
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

## License
MIT
