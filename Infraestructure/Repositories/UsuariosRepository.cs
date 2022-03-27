
namespace Infrastructure.Repositories;
public class UsuarioRepository : IRepository<Core.Entities.Usuario, int>, IUsuarioRepository {

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


    public Task DeleteAsync(Usuario entity) => baseOperations.DeleteAsync(entity);

    public async Task<IReadOnlyList<Usuario>> GetAllAsync() {

        var a =_context.Usuarios;
        return   await _context.Set<Usuario>().ToListAsync();


    }

    public Task<Usuario> GetByIdAsync(int id) => baseOperations.GetByIdAsync(id);

    public Task UpdateAsync(Usuario entity) {
        throw new NotImplementedException();
    }
}

