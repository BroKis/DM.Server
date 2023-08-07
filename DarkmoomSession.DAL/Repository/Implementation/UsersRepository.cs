using DarkmoomSession.DAL.Application;
using DarkmoomSession.DAL.Models;
using DarkmoomSession.DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DarkmoomSession.DAL.Repository.Implementation;

public class UsersRepository:IUsersRepository
{
    private ApplicationContext db;

    public UsersRepository()
    {
        db = new ApplicationContext();
    }
    

    public async Task<IEnumerable<Users>> GetAll()
    {
        return await db.Users.ToListAsync();
    }

    public async Task<bool> Create(Users entity)
    {
        await db.Users.AddAsync(entity);
        await db.SaveChangesAsync();
        return true;
    }

    public async Task<Users> GetById(int id)
    {
        return await db.Users.FirstAsync(x => x.Id == id);
    }

    public async Task<Users> UserByLoginAndPassword(string login, string password)
    {
        return await db.Users.FirstAsync(x => x.Name == login && x.Password == password);
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
}