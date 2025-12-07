using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using EFCore.NamingConventions;

namespace Anidream.DataAccess;

public class AnidreamContextFactory : IDesignTimeDbContextFactory<AnidreamContext>
{
    public AnidreamContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "Anidream.Api"))
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
            .Build();

        var connectionString = Environment.GetEnvironmentVariable("DefaultConnection")
            ?? configuration.GetSection("DefaultConnection").Value 
            ?? configuration.GetConnectionString("DefaultConnection")
            ?? "Host=localhost;Port=5432;Database=Anidream;Username=postgres;Password=UAZ9233;";

        var optionsBuilder = new DbContextOptionsBuilder<AnidreamContext>();
        optionsBuilder.UseNpgsql(connectionString)
            .UseSnakeCaseNamingConvention();

        return new AnidreamContext(optionsBuilder.Options);
    }
}