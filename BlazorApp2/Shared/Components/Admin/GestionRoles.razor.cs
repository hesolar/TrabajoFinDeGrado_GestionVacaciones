namespace BlazorApp2.Pages.Administracion;
public class GestionRolesBase : ComponentBase {

    [Inject]
    public API _api { get; set; }

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    public void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();

    public IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    public IEnumerable<RolesResponse> Roles{ get; set; }
    public RadzenDataGrid<RolesResponse> rolGrid { get; set; }

    protected RolesResponse rolToModify;


    public bool IsLoading = false;



    protected override async Task OnInitializedAsync() {
        await LoadData();
    }

    public async Task LoadData() {
        IsLoading = true;
        this.UsuariosAplicacion = await _api.GetAllUsuariosAsync();
        this.Roles = await _api.GetAllRolesAsync();
        IsLoading = false;
    }


    protected async Task OnUpdateRow(RolesResponse order) {


        if (order == rolToModify) {

            rolToModify = null;
        }
        UpdateRolesCommand u = MapFrom<RolesResponse, UpdateRolesCommand>.Map(order);
        await _api.UpdateRolesAsync(u);


        await LoadData();

    }

    public async Task SaveRow(RolesResponse order) {
        if (insercion && validarRoles(order)) {
            CreateRolesCommand c = MapFrom<RolesResponse, CreateRolesCommand>.Map(order);
            await _api.CreateRolesAsync(c);
            await LoadData();
            insercion = false;
        }
        else await rolGrid.UpdateRow(order);
    }

    public bool validarRoles(RolesResponse order) {
        return !string.IsNullOrEmpty(order.Rol) && order.Id> 0;
    }

    public void CancelEdit(RolesResponse order) {
        if (order == rolToModify) rolToModify = null;
        rolGrid.CancelEditRow(order);
    }

    public async Task DeleteRow(RolesResponse order) {
        if (order == rolToModify) rolToModify = null;


        if (Roles.Contains(order)) {
            DeleteRolesCommand d = MapFrom<RolesResponse, DeleteRolesCommand>.Map(order);
            await _api.DeleteRolesAsync(d);

            await LoadData();
            StateHasChanged();
        }
        else {
            rolGrid.CancelEditRow(order);
        }

    }
    public bool insercion = false;

    protected async Task InsertRow() {
        insercion = true;
        this.rolToModify = new RolesResponse();
        await rolGrid.InsertRow(rolToModify);
    }

    protected async Task EditRow(RolesResponse rol) {
        this.rolToModify = rol;
        await rolGrid.EditRow(rol);
    }
    protected async Task OnCreateRow(RolesResponse order) {
        CreateRolesCommand c = MapFrom<RolesResponse, CreateRolesCommand>.Map(order);
        await _api.CreateRolesAsync(c);
    }
}

