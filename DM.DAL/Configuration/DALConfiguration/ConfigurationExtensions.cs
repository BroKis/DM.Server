using DM.DAL.Models;
using DM.DAL.Application;
using DM.DAL.Configuration.ConnectionConfiguration;
using DM.DAL.Repository.Implementation;
using DM.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DM.DAL.Configuration.DALConfiguration;
/// <summary>
/// Static class for configuration DI-containers
/// </summary>
public static class ConfigurationExtensions
{
    public static void ConfigureDAL(this IServiceCollection services)
    {

        services.AddDbContext<ApplicationContext>(option
            =>
        {
            option.UseMySql(Connector.ConnectString(), new MariaDbServerVersion("11.0.2"));
        });
        
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ISessionRepository, SessionRepository>();
        
       


    }
}