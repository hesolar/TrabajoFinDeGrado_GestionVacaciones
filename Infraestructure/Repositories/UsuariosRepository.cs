
namespace Infrastructure.Repositories;
public class UsuarioRepository :  IUsuarioRepository {

    UsuariosContext _context;
    RepositoryBase<Core.Entities.Usuario, int, UsuariosContext> baseOperations;
    public UsuarioRepository(UsuariosContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public Task<Usuario> AddAsync(Usuario entity) {
        entity.IdTecnico = GenerateKey();
        return baseOperations.AddAsync(entity);
    }
    public int GenerateKey() {
        var context = _context.Usuarios;
        int max = context.Count();
        List<int> ExpectedKeys = Enumerable.Range(0, max).ToList();
        List<int> DBKeys = context.Select(i => i.IdTecnico).ToList();
        return ExpectedKeys.Except(DBKeys).First();
    }



    public  Task<IReadOnlyList<Usuario>> GetAllAsync() =>baseOperations.GetAllAsync();
      

    public Task<Usuario> GetByIdAsync(int id) => baseOperations.GetByIdAsync(id);

  
    public async Task<bool> DeleteAsync(Usuario entity) 
        =>await baseOperations.DeleteAsync(entity);

    public Task<bool> UpdateAsync(Usuario entity)
      =>  baseOperations.UpdateAsync(_context.Usuarios.First(x=> entity.IdTecnico==x.IdTecnico),entity);
}

