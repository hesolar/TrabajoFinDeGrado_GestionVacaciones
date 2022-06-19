namespace Core.Repositories.Base;

public interface IRepository<T, TKey> where T : class {
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> GetByIdAsync(TKey id);
    Task<bool> AddAsync(T entity);
    Task<bool> ReplaceAsync(T newEntity, T oldEntity);
    Task<bool> DeleteAsync(T entity);
    Task<bool> DeleteByIdAsync(TKey entity);
    Task AddManyAsync(IEnumerable<T> entities);
    Task<bool> UpdateAsync(T entity);
}

