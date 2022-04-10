
namespace Infrastructure.Repositories;
public class UsuarioRepository :  IUsuarioRepository {

    UsuariosContext _context;
    RepositoryBase<Core.Entities.Usuario, int, UsuariosContext> baseOperations;
    public UsuarioRepository(UsuariosContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public Task<bool> AddAsync(Usuario entity) 
        => baseOperations.AddAsync(entity);

    public  Task<IReadOnlyList<Usuario>> GetAllAsync() 
        => baseOperations.GetAllAsync();
      
    public Task<Usuario> GetByIdAsync(int id) 
        => baseOperations.GetByIdAsync(id);

    public async Task<bool> DeleteAsync(int entity) 
        => await baseOperations.DeleteAsync(_context.Usuarios.First(x=>x.IdTecnico==entity));

    public async Task<bool> UpdateAsync(Usuario entity)
        =>await baseOperations.UpdateAsync(_context.Usuarios.First(x=> entity.IdTecnico==x.IdTecnico),entity);

    public async Task<Usuario> GetUsuarioByCorreo(string correo) {


            return await Task.FromResult(_context.Usuarios.FirstOrDefault(X => X.EmailCorporativo == correo));

    }

    public async Task<IEnumerable<Usuario>> GetSubordinados(IEnumerable<int> proyectos, int webRol) {
        throw new NotImplementedException();
        HashSet<Usuario> subordinados = new();

        return await _context.Usuarios.Where(u => EsRolSubordinado(webRol, u) && EstaEnProyecto(proyectos, u)).ToListAsync();
        
    }

    private bool EstaEnProyecto(IEnumerable<int> proyectos, Usuario u) => proyectos.Any(p => u.RedmineIdProyecto.HasValue && p == u.RedmineIdProyecto.Value);

    bool EsRolSubordinado(int WebRol, Usuario u)  => u.WebRol < WebRol;
}

