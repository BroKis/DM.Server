using DarkmoomSession.DAL.Configuration.DALConfiguration;
using DarkmoonSession.API.Infrastructure.ProfilesForMapping;
using DarkmoonSession.API.Service.Implementation;

namespace DarkmoonSession.API.Infrastructure.Configuration;

public static class ConfigurationExtensions
{
    public static void ConfigureApi(this IServiceCollection services)
    {
        services.ConfigureDAL();
        services.AddAutoMapper(
            typeof(UsersProfile),
            typeof(SessionProfile));
        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddScoped<IAutorizationService, AutorizationService>();
    }
    
    
}