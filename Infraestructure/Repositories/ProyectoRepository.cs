
namespace Infrastructure.Repositories;
public class ProyectoRepository : RepositoryBase<Core.Entities.Proyecto, int>, IProyectoRepository {
    public ProyectoRepository(Context context) : base(context) { 
    }

    public override async Task<bool> DeleteByIdAsync(int id)
        => await base.DeleteAsync(_context.Proyectos.First(x => x.IdProyecto==id));

    public virtual async Task<bool> UpdateAsync(Proyecto oldEntity, Proyecto newEntity) {
        //Proyecto oldEntity = _context.Proyectos.First(X => X.IdProyecto == entity.IdProyecto);
        return await base.ReplaceAsync(oldEntity, newEntity);
    }
}


