using BlazorApp2.Areas.Identity.Pages.Account.Manage;

namespace BlazorApp2.Shared.Components.Admin; 
public class GestionUsuariosBase: ComponentBase {


    [Inject]
    protected API _api { get; set; }
    
    [Inject]
    protected UserManager<IdentityUser> _userManager { get; set; }

    [Inject]
    protected SignInManager<IdentityUser> _signInManager { get; set; }
    
    [Inject]
    protected ILogger<DeletePersonalDataModel> _logger { get; set; }





    protected IEnumerable<UsuarioResponse> Usuarios { get;  set; }
    protected IEnumerable<RolesResponse> Roles { get;  set; }

    protected override async Task OnInitializedAsync() {
        await LoadData();
    }

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();

    protected IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    protected RadzenDataGrid<UsuarioResponse> UsuariosGrid { get; set; }

    protected UsuarioResponse UsuarioToModify;
    protected bool Loading = false;








    protected async Task LoadData() {
        Loading = true;
        this.Usuarios = await _api.GetAllUsuariosAsync();
        this.Roles = await _api.GetAllRolesAsync();
        StateHasChanged();
        Loading = false;
    }


    protected async Task OnUpdateRow(UsuarioResponse Usuario) {
        if (Usuario == UsuarioToModify) UsuarioToModify = null;     
        UpdateUsuarioCommand u = MapFrom<UsuarioResponse, UpdateUsuarioCommand>.Map(Usuario);
        await _api.UpdateUsuarioAsync(u);
        await LoadData();
    }

    protected async Task SaveRow(UsuarioResponse Usuario) {
        await UsuariosGrid.UpdateRow(Usuario);
    }

    protected bool validarUsuario(UsuarioResponse Usuario) {
        return !string.IsNullOrEmpty(Usuario.EmailCorporativo) && this.Roles.Any(X=> X.Id==Usuario.WebRol);
    }

    protected void CancelEdit(UsuarioResponse Usuario) {
        if (Usuario == UsuarioToModify) UsuarioToModify = null;
        UsuariosGrid.CancelEditRow(Usuario);
    }

    protected async Task DeleteRow(UsuarioResponse usuarioAplicacion) {
        IdentityUser usuarioLogin = _userManager.Users.First(X => X.Email == usuarioAplicacion.EmailCorporativo);
        var result = await _userManager.DeleteAsync(usuarioLogin);
        await DeleteUsuarioEnAplicacion(usuarioLogin,usuarioAplicacion);
    }



    protected async Task DeleteUsuarioEnAplicacion(IdentityUser usuarioLogin, UsuarioResponse usuarioAplicacion) {
        var usuarioxAplicacion = await _api.GetUsuarioByCorreoEmpresaAsync(usuarioLogin.Email);
        DeleteUsuarioCommand d = MapFrom<UsuarioResponse, DeleteUsuarioCommand>.Map(usuarioxAplicacion);
        await _api.DeleteUsuarioAsync(d);
        await LoadData();       
    }


    protected async Task EditRow(UsuarioResponse Usuario) {
        this.UsuarioToModify = Usuario;
        await UsuariosGrid.EditRow(Usuario);
    }
    protected async Task OnCreateRow(UsuarioResponse Usuario) {
        CreateUsuarioCommand c = MapFrom<UsuarioResponse, CreateUsuarioCommand>.Map(Usuario);
        await _api.CreateUsuarioAsync(c);
    }
}
