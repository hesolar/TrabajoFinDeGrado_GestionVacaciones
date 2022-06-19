namespace Core.Repositories;

public interface IUsuarioRepository : IRepositoryBase<Usuario,int>
{
    public Task<Usuario> GetUsuarioByCorreo(String correo);
    public Task<IEnumerable<Usuario>> GetSubordinados(IEnumerable<int> Proyectos, int WebRol);
    //custom operations here
}
