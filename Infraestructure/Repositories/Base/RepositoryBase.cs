using Infraestructure.Data;

namespace Infrastructure.Repositories.Base;

public class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey> where T : class {
    protected readonly Context _context;

    public RepositoryBase(Context context)
        => _context = context;

    public virtual async Task<bool> AddAsync(T entity) {
        await _context.Set<T>().AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }


    public virtual async Task<bool> ReplaceAsync(T oldEntity, T newEntity) {
        PropertyCopier<T, T>.Copy(newEntity, oldEntity);
        
        bool borrado = await DeleteAsync(oldEntity);
        bool insercion = await AddAsync(newEntity);
        

        return borrado&& insercion ?
        await _context.SaveChangesAsync() > 0 : false;
    }

    public virtual async Task<IReadOnlyList<T>> GetAllAsync() {
        var Listado = await _context.Set<T>().ToListAsync();
        return Listado;
    }

    public virtual async Task<T> GetByIdAsync(TKey id) => await _context.Set<T>().FindAsync(id);


    public virtual async Task AddManyAsync(IEnumerable<T> entities) {
        Parallel.ForEach(entities, entity => {
            _context.Set<T>().AddAsync(entity);
        });
        await _context.SaveChangesAsync();
    }



    public virtual async Task<bool> DeleteAsync(T entity) {
        _context.Set<T>().Remove(entity);
        int results = await _context.SaveChangesAsync();
        return results > 0;
    }

    public virtual async Task<bool> DeleteByIdAsync(TKey id) {
        T entity = await GetByIdAsync(id);
        return await DeleteAsync(entity);
    }

 

    public virtual async Task<bool> UpdateAsync(T entity) {

           var cambios =   _context.Update<T>(entity);
           return _context.SaveChanges()!=0;
    }
            
            
}

