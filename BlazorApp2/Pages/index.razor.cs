
namespace BlazorApp2.Pages; 
public class IndexBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    protected API api { get; set; }


    public string UserDisplayedName { get; set; }
    /// <summary>
    /// Añade un nuevo usuario si no existe uno con el correo corporativo dado
    /// </summary>
    /// <returns></returns>
    public async Task ComprobarNuevoUsuario() {

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity;
        UserDisplayedName = userIdentity.Name;
        var usuario = await api.GetUsuarioByCorreoEmpresaAsync(UserDisplayedName);
        if (usuario == null) {
            String apellido = UserDisplayedName.Split('@')[0][1..];
            api.CreateUsuarioAsync(new CreateUsuarioCommand() {
                Nombre = UserDisplayedName,
                Apellido1 = apellido,
                Apellido2 = null,
                Nif = null,
                EmailPersonal = null,
                EmailCorporativo = UserDisplayedName,
                Direccion = null,
                Telefono1 = null,
                Telefono2 = null,
                FechaRegistro = DateTime.Now,
                FechaAltaEmpresa = null,
                FechaBajaEmpresa = null,
                WebContrasena = null,
                WebRol = 0,
                SeguimientNotificacion = 0,
                SeguimientoFecha = null,
                SeguimientoIntervalo = null,
                EmpresaTarifa = 0,
                EmpresaCategoria = 0,
                ClienteCuenta = null,
                ClienteCategoria = 0,
                ClienteNivel = null,
                RedmineAPIKey = null,
                RedmineIdProyecto = null
            });
        }
    }

}
