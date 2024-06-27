using Microsoft.AspNetCore.Builder; // потрібна для WebApplication (за замовчуванням вже знаходиться у .NET 6)
using Microsoft.Extensions.Configuration; // потрібна для WebApplicationBuilder (за замовчуванням вже знаходиться у .NET 6)

namespace ArtForHeartShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Метод CreateBuilder(args) повертає екземпляр WebApplicationBuilder
            // Тут зберігатимуться налаштування проекту з appsettings.json перед запуском

            // При запуску WebApplication.CreateBuilder(args),
            // автоматично створює і налаштовує конфігураційний провайдер (ConfigurationProvider) і
            // повертає екземпляр класу WebApplicationBuilder 

            // За замовчуванням він додасть лише основні файли конфігурації,
            // такі як appsettings.json та appsettings.{Environment}.json (appsettings.Development.json або appsettings.Production.json)
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // Конфігурація за замовчуванням
            builder.Configuration
                // Основний файл конфігурації, який завжди додається.
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

                // optional:
                    // false --> Файл конфігурації є обов'язковим (якщо файл відсутній, програма не запуститься і видасть помилку).
                    // true --> Файл конфігурації є необов'язковим.

                // reloadOnChange: 
                    // true --> Конфігурація автоматично оновлюється (якщо файл конфігурації змінюється під час роботи програми).
                    // false --> Конфігурація не оновлюється автоматично (для застосування змін необхідно перезапустити програму).
                .AddJsonFile("appsettings.ExampleSettings.json", optional: true, reloadOnChange: true)

                // Файли конфігурації для різних середовищ.
                // {Environment} замінюється на поточне середовище (наприклад, Development, Staging, Production).
                // Файли додаються тільки якщо вони існують(optional: true).
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            // Mетод Build() повертає екземпляр WebApplication на основі налаштувань WebApplicationBuilder.
            // Об'єкт, який фактично буде представляти веб-застосунок і обробляти HTTP-запити.
            WebApplication app = builder.Build();

            // Основні методи ASP.NET Core CRUD маршрутів:
                // MapGet (READ),
                // MapPost (CREATE),
                // MapPut (UPDATE),
                // MapDelete (DELETE)
            app.MapGet("/", () => "Hello World!");

            // Запуск додатку
            app.Run();
        }
    }
}
