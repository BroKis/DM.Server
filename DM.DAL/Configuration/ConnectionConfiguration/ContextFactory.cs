using DM.DAL.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DM.DAL.Configuration.ConnectionConfiguration;
/// <summary>
/// Factory for configuration ApplicationContext
/// </summary>
public class ContextFactory:IDesignTimeDbContextFactory<ApplicationContext>
{
    public ApplicationContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder();
        // установка пути к текущему каталогу
        builder.SetBasePath(Directory.GetCurrentDirectory());
        // получаем конфигурацию из файла appsettings.json
        builder.AddJsonFile("appsettings.json");
        var config = builder.Build();
        // получаем строку подключения
        string connectionString
            = config.GetConnectionString("DefaultConnection");
        var optionsBuilder =
            new DbContextOptionsBuilder<ApplicationContext>();
        var serviceVersion = new MariaDbServerVersion(new Version(11, 0, 2));
        DbContextOptions<ApplicationContext> options
            = optionsBuilder
                .UseMySql(connectionString,serviceVersion).Options;
        return new ApplicationContext(optionsBuilder.Options);
    }
}