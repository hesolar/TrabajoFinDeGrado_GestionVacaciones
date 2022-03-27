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

        public async Task DeleteAsync(T entity) {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();




        public async Task<T> GetByIdAsync(TKey id) => await _context.Set<T>().FindAsync(id);


        public async Task UpdateAsync(T entity) {
            //await _context.Set<T>().Where(x=>x.)
        }
    }

