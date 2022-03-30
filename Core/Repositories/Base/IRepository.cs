namespace Core.Repositories.Base;

public interface IRepository<T,TKey> where T : class {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(TKey id);
    Task<bool> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
}

