namespace SaraTort.DAL.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<T> Repository<T>() where T : class;
    Task<bool> SaveAsync();
}