namespace DarkmoomSession.DAL.Repository.Interfaces;

public interface IRepository<T>:IDisposable where T:class
{
    Task<IEnumerable<T>> GetAll();
    Task<bool> Create(T entity);

    Task<T> GetById(int id);
}