
namespace BlazorApp2.Pages; 
public class IndexBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    protected API Api { get; set; }


    public string UserDisplayedName { get; set; }
    /// <summary>
    /// Añade un nuevo usuario si no existe uno con el correo corporativo dado
    /// </summary>
    /// <returns></returns>
    public async Task ComprobarNuevoUsuario() {

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity;
        UserDisplayedName = userIdentity.Name;
        var UsuarioAplicacion = await Api.GetUsuarioByCorreoEmpresaAsync(UserDisplayedName);
        if (UsuarioAplicacion == null) {
            String apellido = UserDisplayedName.Split('@')[0][1..];

           var d = MapFrom<UsuarioResponse, CreateUsuarioCommand>.Map(UsuarioAplicacion);
           await Api.CreateUsuarioAsync(d);
            
        }
    }

    protected override async Task OnParametersSetAsync() =>
       ComprobarNuevoUsuario();

}
