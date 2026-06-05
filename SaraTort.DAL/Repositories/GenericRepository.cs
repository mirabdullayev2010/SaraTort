using Microsoft.EntityFrameworkCore;
using SaraTort.DAL.Interfaces;
using SaraTort.DAL.Persistence;
using System.Linq.Expressions;

namespace SaraTort.DAL.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly AppDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null, string[]? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (expression != null)
            query = query.Where(expression);

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return await query.ToListAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> expression, string[]? includes = null)
    {
        IQueryable<T> query = _dbSet;

        if (includes != null)
        {
            foreach (var include in includes)
                query = query.Include(include);
        }

        return await query.FirstOrDefaultAsync(expression);
    }

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);
}