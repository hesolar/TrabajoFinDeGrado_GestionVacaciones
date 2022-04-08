
namespace Infrastructure.Repositories;
public class UsuarioProyectoRepository:  IUsuarioProyectoRepository {

    UsuarioProyectoContext _context;
    RepositoryBase<Core.Entities.UsuarioProyecto, int, UsuarioProyectoContext> baseOperations;

    public UsuarioProyectoRepository(UsuarioProyectoContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public async Task<bool> AddAsync(UsuarioProyecto entity) 
      => await baseOperations.AddAsync(entity);
    

    public async Task<bool> DeleteAsync(Tuple<int, int> entity) 
         => await baseOperations.DeleteAsync(_context.UsuarioProyecto.First(x => x.IdTecnico == entity.Item1 && x.IdProyecto == entity.Item2));

    public async Task<IReadOnlyList<UsuarioProyecto>> GetAllAsync()  => await baseOperations.GetAllAsync();
    

    public async Task<UsuarioProyecto> GetByIdAsync(Tuple<int, int> id) => await _context.Set<UsuarioProyecto>().FindAsync(id.Item1, id.Item2);

     public async Task<IEnumerable<int>> GetProyectosUsuario(int Usuario) =>
        await _context.UsuarioProyecto.Where(X => X.IdTecnico == Usuario).Select(X => X.IdProyecto).ToListAsync();

    public async Task<IEnumerable<int>> GetUsuarioProyectos(int proyecto)=>
        await _context.UsuarioProyecto.Where(X => X.IdProyecto == proyecto).Select(X => X.IdTecnico).ToListAsync();


    public Task<bool> NuevoProyectoUsuario(int IdProyecto, int idTecnico) 
        => AddAsync( new UsuarioProyecto() { IdTecnico = idTecnico, IdProyecto = IdProyecto });
    

    public async Task<bool> UpdateAsync(UsuarioProyecto entity) {
        var OldEntity = _context.UsuarioProyecto.First(X => X.IdTecnico == entity.IdTecnico && X.IdProyecto == entity.IdProyecto);
        return await baseOperations.UpdateAsync(OldEntity, entity); ;
    }
}

