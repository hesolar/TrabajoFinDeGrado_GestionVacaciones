namespace BlazorApp2.Shared.Components.GestionEquipo.ComboVacacionesUsuario; 
public class CalendarioPorUsuariosBase: ComponentBase {
    [Parameter] public ProyectoResponse Proyecto { get; set; }
    [Parameter] public API _api { get; set; }
    protected  List<UsuarioResponse> usuarios = new();

    protected String value;
    protected RadzenListBox<String> ListBoxUsuarios;
    protected bool hide;

    protected IEnumerable<TipoDiaCalendarioResponse> ColoresBotones;

    protected UsuarioResponse usuarioSeleccionado;
    protected override async Task OnInitializedAsync() {

        ColoresBotones = await _api.GetAllTipoDiaCalendarioAsync();
        IEnumerable<int> idUsuarios = await _api.GetUsuariosProyectoAsync(Proyecto.IdProyecto);
        foreach (var idUsuario in idUsuarios) {
            UsuarioResponse usuario = await _api.GetUsuarioByIdAsync(idUsuario);
            this.usuarios.Add(usuario);
        }
    }
    protected async Task OnChange() {
        string correo = this.ListBoxUsuarios.SelectedItem.ToString();
        this.usuarioSeleccionado = await _api.GetUsuarioByCorreoEmpresaAsync(correo);
        StateHasChanged();
        hide = false;
        StateHasChanged();
        hide = true;


        StateHasChanged();
    }
}
