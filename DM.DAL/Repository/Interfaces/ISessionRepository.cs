using DM.DAL.Models;

namespace DM.DAL.Repository.Interfaces;
/// <summary>
/// Interface which implements basic interface
/// </summary>
public interface ISessionRepository:IRepository<Sessions>
{
    Task<Sessions> GetByToken(string token);
}