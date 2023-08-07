using DarkmoonSession.API.Infrastructure.Respounce;
using DarkmoonSession.API.ModelsDTO;

namespace DarkmoonSession.API.Service.Implementation;

public interface IAutorizationService
{
    public Task<Responce<object>> SessionCreate(UsersDTO users);
    public Task<UsersDTO> UsersGetByAuth(AuthModel auth);

    public Task<Responce<object>> UsersGetByToken(string token);
}