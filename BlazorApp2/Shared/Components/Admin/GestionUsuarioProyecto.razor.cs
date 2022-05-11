namespace BlazorApp2.Shared.Components.Admin; 
public class GestionUsuarioProyectoBase : ComponentBase  {
    [Inject]
    public API _api { get; set; }

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    public void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();


    public IEnumerable<UsuarioProyectoResponse> UsuariosEnProyectos;
    public IEnumerable<ProyectoResponse> Proyectos;
    public IEnumerable<UsuarioResponse> Usuarios;
    public UsuarioProyectoResponse UsuarioProyectoToModify;


    public RadzenDataGrid<UsuarioProyectoResponse> usuarioProyectoGrid { get; set; }



    public bool insercion = false;
    public bool IsLoading = false;



    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        await LoadData();
        IsLoading = false;
    }

    public async Task LoadData() {
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

    public async Task SaveRow(UsuarioProyectoResponse order) {
        if (insercion && validarUsuarioProyecto(order)) {
            CreateUsuarioProyectoCommand c = MapFrom<UsuarioProyectoResponse, CreateUsuarioProyectoCommand>.Map(order);
            await _api.CreateUsuarioProyectoAsync(c);
            await LoadData();
            insercion = false;
            this.UsuarioProyectoToModify = null;
        }
        else await usuarioProyectoGrid.UpdateRow(order);
    }

    public bool validarUsuarioProyecto(UsuarioProyectoResponse usuarioRolesProyecto) {
        return this.Usuarios.Select(X => X.IdTecnico).Contains(usuarioRolesProyecto.IdTecnico)
                && this.Proyectos.Select(X => X.IdProyecto).Contains(usuarioRolesProyecto.IdProyecto);
    }

    public void CancelEdit(UsuarioProyectoResponse usuarioProyectoToModify) {
        if (usuarioProyectoToModify == UsuarioProyectoToModify) UsuarioProyectoToModify = null;
        usuarioProyectoGrid.CancelEditRow(usuarioProyectoToModify);
    }

    public async Task DeleteRow(UsuarioProyectoResponse usuarioProyectoToModify) {
        if (usuarioProyectoToModify == UsuarioProyectoToModify) UsuarioProyectoToModify = null;


        
            DeleteUsuarioProyectoCommand d = MapFrom<UsuarioProyectoResponse, DeleteUsuarioProyectoCommand>.Map(usuarioProyectoToModify);
            await _api.DeleteUsuarioProyectoAsync(d);

            await LoadData();
            StateHasChanged();
        
        
            //rolGrid.CancelEditRow(order);
        

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
    protected async Task OnCreateRow(UsuarioProyectoResponse usuarioProyectoResponse) {
        //CreateUsuarioProyectoCommand c = MapFrom<UsuarioProyectoResponse, CreateUsuarioProyectoCommand>.Map(usuarioProyectoResponse);
        //await _api.CreateUsuarioProyectoAsync(c);
    }

}
