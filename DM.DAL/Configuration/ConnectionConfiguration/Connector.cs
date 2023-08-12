using Microsoft.Extensions.Configuration;

namespace DM.DAL.Configuration.ConnectionConfiguration;
/// <summary>
/// Static class with static method which return connection string
/// </summary>
public class Connector
{
    public static string ConnectString()
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
        return connectionString;
    }
}