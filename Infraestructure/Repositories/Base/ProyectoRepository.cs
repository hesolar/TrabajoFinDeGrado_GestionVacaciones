
namespace Infrastructure.Repositories;
public class ProyectoRepository : IProyectoRepository {
    readonly ProyectosContext _context;
    readonly RepositoryBase<Core.Entities.Proyecto, Tuple<int, DateTime>, ProyectosContext> baseOperations;
    public ProyectoRepository(ProyectosContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public Task<bool> AddAsync(Proyecto entity) 
        => baseOperations.AddAsync(entity);
    

    public Task<bool> DeleteAsync(int id)
        => baseOperations.DeleteAsync(_context.Proyectos.First(x => x.IdProyecto==id));

    public Task<IReadOnlyList<Proyecto>> GetAllAsync() 
        => baseOperations.GetAllAsync();

    public async Task<Proyecto> GetByIdAsync(int id)
        => await _context.Set<Proyecto>().FindAsync(id);
    

    public Task<bool> UpdateAsync(Proyecto entity) {
        Proyecto oldEntity = _context.Proyectos.First(X => X.IdProyecto == entity.IdProyecto);
        return baseOperations.UpdateAsync(oldEntity, entity);
    }
}


