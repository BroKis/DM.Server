using DarkmoomSession.DAL.Application;
using DarkmoomSession.DAL.Configuration.ConnectionConfiguration;
using DarkmoomSession.DAL.Models;
using DarkmoomSession.DAL.Repository.Implementation;
using DarkmoomSession.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DarkmoomSession.DAL.Configuration.DALConfiguration;

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