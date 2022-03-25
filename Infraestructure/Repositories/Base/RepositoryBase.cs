


namespace Infrastructure.Repositories.Base;

public class RepositoryBase<T, DB> where T : class where DB : DbContext{
    protected readonly DB _context;

    public RepositoryBase(DB context) {
        _context = context;
    }
    public async Task<T> AddAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task DeleteAsync(T entity) {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id) {
        return await _context.Set<T>().FindAsync(id);
    }

    public Task UpdateAsync(T entity) {
        throw new NotImplementedException();
    }
}

