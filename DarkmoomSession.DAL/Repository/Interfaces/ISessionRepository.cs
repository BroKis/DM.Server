using DarkmoomSession.DAL.Models;

namespace DarkmoomSession.DAL.Repository.Interfaces;

public interface ISessionRepository:IRepository<Sessions>
{
    Task<Sessions> GetByToken(string token);
}