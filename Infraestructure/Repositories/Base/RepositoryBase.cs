namespace Infrastructure.Repositories.Base;

public class RepositoryBase<T, TKey, DB> where T : class where DB : DbContext {
    protected readonly DB _context;

    public RepositoryBase(DB context) 
        => _context = context;
    
    public async Task<bool> AddAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0 ;
    }

    public async Task<bool> DeleteAsync(T entity) {
        _context.Set<T>().Remove(entity);
       int results= await _context.SaveChangesAsync();
        return results >0;
    }
    public async Task<bool> UpdateAsync(T oldEntity, T newEntity) {
        PropertyCopier<T,T>.Copy(newEntity, oldEntity);
        _context.Set<T>().Update(oldEntity);
        return await _context.SaveChangesAsync()>0;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

    public async Task<T> GetByIdAsync(TKey id) => await _context.Set<T>().FindAsync(id);

}

