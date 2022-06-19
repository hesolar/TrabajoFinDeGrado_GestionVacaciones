namespace Infrastructure.Repositories;

public class TecnicoProyectosRepository : RepositoryBase<Core.Entities.TecnicoProyectos, int>, ITecnicoProyectosRepository {

    public TecnicoProyectosRepository(Context context) : base(context) {
    }


    public override async Task<bool> DeleteByIdAsync(int id)
        => await base.DeleteAsync(_context.TecnicoProyectos.First(x => x.IdTecnicoProyecto == id));

    public override async Task<bool> UpdateAsync(TecnicoProyectos oldEntity,TecnicoProyectos newEntity)
      => await base.UpdateAsync(oldEntity,newEntity);
}

