namespace Core.Repositories.Base;

public interface IRepository<T,TKey> where T : class {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(TKey id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}

