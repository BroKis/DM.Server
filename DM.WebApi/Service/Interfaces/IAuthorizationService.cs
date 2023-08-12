


using DM.API.ModelsDTO;

namespace DM.API.Service.Interfaces;

public interface IAuthorizationService
{
    public Task<object> SessionCreate(UsersDTO users);
    public Task<UsersDTO> UsersGetByAuth(AuthModel auth);

    public Task<object> UsersGetByToken(string token);
}