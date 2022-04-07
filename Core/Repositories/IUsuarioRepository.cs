namespace Core.Repositories;

public interface IUsuarioRepository : IRepository<Usuario,int>
{
    public Task<Usuario> GetUsuarioByCorreo(String correo);
    //custom operations here
}
