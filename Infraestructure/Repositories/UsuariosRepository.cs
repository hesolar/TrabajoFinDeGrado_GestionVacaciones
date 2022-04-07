
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

    public Task<bool> UpdateAsync(Usuario entity)
        => baseOperations.UpdateAsync(_context.Usuarios.First(x=> entity.IdTecnico==x.IdTecnico),entity);

    public Task<Usuario> GetUsuarioByCorreo(string correo) {


            return Task.FromResult(_context.Usuarios.FirstOrDefault(X => X.EmailCorporativo == correo));

    }
    
}

