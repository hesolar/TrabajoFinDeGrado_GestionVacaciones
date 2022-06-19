namespace Core.Repositories;

public interface IUsuarioProyectoRepository : IRepositoryBase<UsuarioProyecto, Tuple<int, int>> {

    public Task<IEnumerable <int>> GetProyectosUsuario(int Usuario);
    public Task<IEnumerable <int>> GetUsuarioProyectos(int proyecto);
    public Task<bool> NuevoProyectoUsuario(int Proyecto, int Usuario);
}
