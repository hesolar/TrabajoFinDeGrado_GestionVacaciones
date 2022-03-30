
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
    
    public int GenerateKey() 
        => throw new NotImplementedException();
    
    public  Task<IReadOnlyList<Usuario>> GetAllAsync() 
        => baseOperations.GetAllAsync();
      
    public Task<Usuario> GetByIdAsync(int id) 
        => baseOperations.GetByIdAsync(id);

    public async Task<bool> DeleteAsync(Usuario entity) 
        => await baseOperations.DeleteAsync(entity);

    public Task<bool> UpdateAsync(Usuario entity)
        => baseOperations.UpdateAsync(_context.Usuarios.First(x=> entity.IdTecnico==x.IdTecnico),entity);
}

