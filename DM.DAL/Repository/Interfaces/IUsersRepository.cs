using DM.DAL.Models;

namespace DM.DAL.Repository.Interfaces;
/// <summary>
/// Interface which implements basic interface
/// </summary>
public interface IUsersRepository:IRepository<Users>
{
    Task<Users> UserByLoginAndPassword(string login, string password);
}