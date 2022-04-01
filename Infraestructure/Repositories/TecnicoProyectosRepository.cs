namespace Infrastructure.Repositories;

public class TecnicoProyectosRepository : ITecnicoProyectosRepository {
    
    TecnicoProyectosContext _context;
    RepositoryBase<Core.Entities.TecnicoProyectos, int, TecnicoProyectosContext> baseOperations;
    public TecnicoProyectosRepository(TecnicoProyectosContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public Task<bool> AddAsync(TecnicoProyectos entity)
        => baseOperations.AddAsync(entity);


    public Task<IReadOnlyList<TecnicoProyectos>> GetAllAsync()
        => baseOperations.GetAllAsync();


    public Task<TecnicoProyectos> GetByIdAsync(int id)
        => baseOperations.GetByIdAsync(id);

    public async Task<bool> DeleteAsync(int id)
        => await baseOperations.DeleteAsync(_context.TecnicoProyectos.First(x => x.IdTecnicoProyecto == id));

    public Task<bool> UpdateAsync(TecnicoProyectos entity)
      => baseOperations.UpdateAsync(_context.TecnicoProyectos.First(x => x.IdTecnico == entity.IdTecnico),entity);
}

