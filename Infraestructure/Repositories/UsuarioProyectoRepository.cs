
namespace Infrastructure.Repositories;
public class UsuarioProyectoRepository: RepositoryBase<Core.Entities.UsuarioProyecto, Tuple<int, int>>, IUsuarioProyectoRepository {
   

    public UsuarioProyectoRepository(Context context):base(context) {

    }

    public override async Task<bool> AddAsync(UsuarioProyecto entity) 
      => await base.AddAsync(entity);
    

    public override async Task<bool> DeleteByIdAsync(Tuple<int, int> key) 
         => await base.DeleteAsync(_context.UsuarioProyecto.First(x => x.IdTecnico == key.Item1 && x.IdProyecto == key.Item2));

    

    public override async Task<UsuarioProyecto> GetByIdAsync(Tuple<int, int> id) => await _context.Set<UsuarioProyecto>().FindAsync(id.Item1, id.Item2);

     public async Task<IEnumerable<int>> GetProyectosUsuario(int Usuario) =>
        await _context.UsuarioProyecto.Where(X => X.IdTecnico == Usuario).Select(X => X.IdProyecto).ToListAsync();

    public async Task<IEnumerable<int>> GetUsuarioProyectos(int proyecto)=>
        await _context.UsuarioProyecto.Where(X => X.IdProyecto == proyecto).Select(X => X.IdTecnico).ToListAsync();


    public Task<bool> NuevoProyectoUsuario(int idTecnico, int IdProyecto) 
        => AddAsync( new UsuarioProyecto() { IdTecnico = idTecnico, IdProyecto = IdProyecto });
    

    public async Task<bool> UpdateAsync(UsuarioProyecto oldEntity , UsuarioProyecto newEntity) {
        //var OldEntity = _context.UsuarioProyecto.First(X => X.IdTecnico == entity.IdTecnico && X.IdProyecto == entity.IdProyecto);
        return await base.ReplaceAsync(oldEntity, newEntity); ;
    }
}

