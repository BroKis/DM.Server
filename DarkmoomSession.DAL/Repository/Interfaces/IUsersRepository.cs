using DarkmoomSession.DAL.Models;

namespace DarkmoomSession.DAL.Repository.Interfaces;

public interface IUsersRepository:IRepository<Users>
{
    Task<Users> UserByLoginAndPassword(string login, string password);
}