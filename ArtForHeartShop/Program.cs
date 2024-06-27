using Microsoft.AspNetCore.Builder; // ������� ��� WebApplication (�� ������������� ��� ����������� � .NET 6)
using Microsoft.Extensions.Configuration; // ������� ��� WebApplicationBuilder (�� ������������� ��� ����������� � .NET 6)

namespace ArtForHeartShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ����� CreateBuilder(args) ������� ��������� WebApplicationBuilder
            // ��� �������������� ������������ ������� � appsettings.json ����� ��������

            // ��� ������� WebApplication.CreateBuilder(args),
            // ����������� ������� � ��������� ��������������� ��������� (ConfigurationProvider) �
            // ������� ��������� ����� WebApplicationBuilder 

            // �� ������������� �� ������� ���� ������ ����� ������������,
            // ��� �� appsettings.json �� appsettings.{Environment}.json (appsettings.Development.json ��� appsettings.Production.json)
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            // ������������ �� �������������
            builder.Configuration
                // �������� ���� ������������, ���� ������ ��������.
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)

                // optional:
                    // false --> ���� ������������ � ����'������� (���� ���� �������, �������� �� ����������� � ������� �������).
                    // true --> ���� ������������ � ������'�������.

                // reloadOnChange: 
                    // true --> ������������ ����������� ����������� (���� ���� ������������ ��������� �� ��� ������ ��������).
                    // false --> ������������ �� ����������� ����������� (��� ������������ ��� ��������� ������������� ��������).
                .AddJsonFile("appsettings.ExampleSettings.json", optional: true, reloadOnChange: true)

                // ����� ������������ ��� ����� ���������.
                // {Environment} ���������� �� ������� ���������� (���������, Development, Staging, Production).
                // ����� ��������� ����� ���� ���� �������(optional: true).
                .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            // M���� Build() ������� ��������� WebApplication �� ����� ����������� WebApplicationBuilder.
            // ��'���, ���� �������� ���� ������������ ���-���������� � ��������� HTTP-������.
            WebApplication app = builder.Build();

            // ������ ������ ASP.NET Core CRUD ��������:
                // MapGet (READ),
                // MapPost (CREATE),
                // MapPut (UPDATE),
                // MapDelete (DELETE)
            app.MapGet("/", () => "Hello World!");

            // ������ �������
            app.Run();
        }
    }
}
