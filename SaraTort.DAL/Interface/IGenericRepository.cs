using System.Linq.Expressions;

namespace SaraTort.DAL.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null);
    Task<T?> GetAsync(Expression<Func<T, bool>> expression, string[]? includes = null);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}