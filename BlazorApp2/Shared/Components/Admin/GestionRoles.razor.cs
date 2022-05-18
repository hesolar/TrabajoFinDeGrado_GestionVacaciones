namespace BlazorApp2.Pages.Administracion;
public class GestionRolesBase : ComponentBase {

    [Inject] protected API _api { get; set; }

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();
    protected IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    protected IEnumerable<RolesResponse> Roles{ get; set; }
    protected RadzenDataGrid<RolesResponse> rolGrid { get; set; }
    protected RolesResponse rolToModify;
    protected bool IsLoading = false;
    protected bool insercion = false;


    protected override async Task OnInitializedAsync() {
        await LoadData();
    }

    protected async Task LoadData() {
        IsLoading = true;
        this.UsuariosAplicacion = await _api.GetAllUsuariosAsync();
        this.Roles = await _api.GetAllRolesAsync();
        IsLoading = false;
        StateHasChanged();
    }


    protected async Task OnUpdateRow(RolesResponse order) {
        if (order == rolToModify) rolToModify = null;
        UpdateRolesCommand u = MapFrom<RolesResponse, UpdateRolesCommand>.Map(order);
        await _api.UpdateRolesAsync(u);
        await LoadData();
    }

    protected async Task SaveRow(RolesResponse order) {
        if (insercion && validarRoles(order)) {
            CreateRolesCommand c = MapFrom<RolesResponse, CreateRolesCommand>.Map(order);
            await _api.CreateRolesAsync(c);
            await LoadData();
            insercion = false;
        }
        else await rolGrid.UpdateRow(order);
    }

    protected bool validarRoles(RolesResponse order) 
        => !string.IsNullOrEmpty(order.Rol) && order.Id> 0;
    

    protected async void CancelEdit(RolesResponse order) {
        if (order == rolToModify) rolToModify = null;
        rolGrid.CancelEditRow(order);
        await LoadData();
    }

    protected async Task DeleteRow(RolesResponse order) {
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

