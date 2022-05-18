namespace BlazorApp2.Shared.Components.Admin; 
public class GestionUsuarioProyectoBase : ComponentBase  {
    [Inject] public API _api { get; set; }
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();
    protected IEnumerable<UsuarioProyectoResponse> UsuariosEnProyectos;
    protected IEnumerable<ProyectoResponse> Proyectos;
    protected IEnumerable<UsuarioResponse> Usuarios;
    protected UsuarioProyectoResponse UsuarioProyectoToModify;
    protected RadzenDataGrid<UsuarioProyectoResponse> usuarioProyectoGrid { get; set; }
    protected bool insercion = false;
    protected bool IsLoading = false;



    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        await LoadData();
        IsLoading = false;
    }

    protected async Task LoadData() {
        this.UsuariosEnProyectos = await _api.GetAllUsuarioProyectoAsync();
        //Elimina el proyecto inicial
        var  proyectosTotales = await _api.GetAllProyectosAsync();
        proyectosTotales.Remove(proyectosTotales.First(X => X.Nombre == "ProyectoInicial"));
        this.Proyectos = proyectosTotales;
        this.Usuarios = await _api.GetAllUsuariosAsync();
    }

    protected async Task OnUpdateRow(UsuarioProyectoResponse usuarioProyecto) {
        if (usuarioProyecto == UsuarioProyectoToModify) UsuarioProyectoToModify = null;   
        UpdateRolesCommand u = MapFrom<UsuarioProyectoResponse, UpdateRolesCommand>.Map(usuarioProyecto);
        await _api.UpdateRolesAsync(u);
        await LoadData();
    }

    protected async Task SaveRow(UsuarioProyectoResponse order) {
        if (insercion && validarUsuarioProyecto(order)) {
            CreateUsuarioProyectoCommand c = MapFrom<UsuarioProyectoResponse, CreateUsuarioProyectoCommand>.Map(order);
            await _api.CreateUsuarioProyectoAsync(c);
            await LoadData();
            insercion = false;
            this.UsuarioProyectoToModify = null;
        }
        else await usuarioProyectoGrid.UpdateRow(order);
    }

    protected bool validarUsuarioProyecto(UsuarioProyectoResponse usuarioRolesProyecto) =>
        this.Usuarios.Select(X => X.IdTecnico).Contains(usuarioRolesProyecto.IdTecnico)
        && this.Proyectos.Select(X => X.IdProyecto).Contains(usuarioRolesProyecto.IdProyecto);
    

    protected void CancelEdit(UsuarioProyectoResponse usuarioProyectoToModify) {
        if (usuarioProyectoToModify == UsuarioProyectoToModify) UsuarioProyectoToModify = null;
        usuarioProyectoGrid.CancelEditRow(usuarioProyectoToModify);
    }

    public async Task DeleteRow(UsuarioProyectoResponse usuarioProyectoToModify) {
        if (usuarioProyectoToModify == UsuarioProyectoToModify) UsuarioProyectoToModify = null;
            DeleteUsuarioProyectoCommand d = MapFrom<UsuarioProyectoResponse, DeleteUsuarioProyectoCommand>.Map(usuarioProyectoToModify);
            await _api.DeleteUsuarioProyectoAsync(d);
            await LoadData();
            StateHasChanged();
    }

    protected async Task InsertRow() {
        insercion = true;
        this.UsuarioProyectoToModify = new UsuarioProyectoResponse();
        await usuarioProyectoGrid.InsertRow(UsuarioProyectoToModify);
    }

    protected async Task EditRow(UsuarioProyectoResponse usuarioProyectoResponse) {
        this.UsuarioProyectoToModify = usuarioProyectoResponse;
        await usuarioProyectoGrid.EditRow(usuarioProyectoResponse);
    }

}
