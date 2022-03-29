namespace Infrastructure.Repositories.Base;

public class RepositoryBase<T, TKey, DB> where T : class where DB : DbContext {
    protected readonly DB _context;

    public RepositoryBase(DB context) {
        _context = context;
    }
    public async Task<T> AddAsync(T entity) {

        await _context.Set<T>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(T entity) {

        _context.Set<T>().Remove(entity);
       int results= await _context.SaveChangesAsync();
        return results >0;
    }
    public async Task<bool> UpdateAsync(T oldEntity, T newEntity) {
        
        await DeleteAsync(oldEntity);
        await AddAsync(newEntity);    
       int i =  await _context.SaveChangesAsync();
        return i>0;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();




    public async Task<T> GetByIdAsync(TKey id) => await _context.Set<T>().FindAsync(id);


    public  async Task<bool> ReplaceOldByNew<T>( List<T> list, Predicate<T> oldItemSelector, T newItem) {
        var oldItemIndex = list.FindIndex(oldItemSelector);
        list[oldItemIndex] = newItem;
        return true;
    }
    public  async Task<bool> Deletion<T>(List<T> list, Predicate<T> oldItemSelector) {
        var oldItemIndex = list.FindIndex(oldItemSelector);
        list.RemoveAt(oldItemIndex);
        return true;
    }
}

