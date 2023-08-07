using DarkmoomSession.DAL.Application;
using DarkmoomSession.DAL.Models;
using DarkmoomSession.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DarkmoomSession.DAL.Repository.Implementation;

public class SessionRepository:ISessionRepository
{

    private ApplicationContext db;

    public SessionRepository()
    {
        db = new ApplicationContext();
    }
    private bool disposed = false;

    public virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        this.disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<IEnumerable<Sessions>> GetAll()
    {
        return await db.Session.ToListAsync();
    }

    public async Task<bool> Create(Sessions entity)
    {
        await db.Session.AddAsync(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<Sessions> GetById(int id)
    {
        return await db.Session.FirstAsync(x => x.Id == id);
    }

    public async Task<Sessions> GetByToken(string token)
    {
        return await db.Session.FirstAsync(x => x.Token == token);
    }
}