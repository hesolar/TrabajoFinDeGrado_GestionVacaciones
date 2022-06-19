
namespace Infrastructure.Repositories;
public class UsuarioRepository : RepositoryBase<Core.Entities.Usuario, int>, IUsuarioRepository {


    public UsuarioRepository(Context context) : base(context) {
    }

    public override async Task<bool> DeleteByIdAsync(int entity)
        => await base.DeleteAsync(_context.Usuarios.First(x => x.IdTecnico == entity));

    public async Task<bool> UpdateAsync(Usuario entity)
        => await base.UpdateAsync(_context.Usuarios.First(x => entity.IdTecnico == x.IdTecnico), entity);

    public async Task<Usuario> GetUsuarioByCorreo(string correo) {
        return await Task.FromResult(_context.Usuarios.FirstOrDefault(X => X.EmailCorporativo == correo));
    }

    public async Task<IEnumerable<Usuario>> GetSubordinados(IEnumerable<int> proyectos, int webRol) {
        HashSet<Usuario> subordinados = new();
        return await _context.Usuarios.Where(u => EsRolSubordinado(webRol, u) && EstaEnProyecto(proyectos, u)).ToListAsync();
    }

    private bool EstaEnProyecto(IEnumerable<int> proyectos, Usuario u) => proyectos.Any(p => u.RedmineIdProyecto.HasValue && p == u.RedmineIdProyecto.Value);

    bool EsRolSubordinado(int WebRol, Usuario u) => u.WebRol < WebRol;
}

