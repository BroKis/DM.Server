using DM.API.Infrastructure.ProfilesForMapping;
using DM.API.Service.Implementation;
using DM.API.Service.Interfaces;
using DM.DAL.Configuration.DALConfiguration;

namespace DM.API.Infrastructure.Configuration;
/// <summary>
/// Static class for configuration DI-containers
/// </summary>
public static class ConfigurationExtensions
{
    public static void ConfigureApi(this IServiceCollection services)
    {
        services.ConfigureDAL();
        services.AddAutoMapper(
            typeof(UsersProfile),
            typeof(SessionProfile));
        services.AddAutoMapper(typeof(Program).Assembly);

        services.AddScoped<IAuthorizationService, AuthorizationService>();
    }
    
    
}