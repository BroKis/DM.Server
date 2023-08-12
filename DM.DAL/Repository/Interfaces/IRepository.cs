namespace DM.DAL.Repository.Interfaces;
/// <summary>
/// Interface with basic methods for implementation in derivatives classes
/// </summary>
/// <typeparam name="T">Generic type</typeparam>
public interface IRepository<T>:IDisposable where T:class
{
    Task<IEnumerable<T>> GetAll();
    Task<bool> Create(T entity);

    Task<T> GetById(int id);
}