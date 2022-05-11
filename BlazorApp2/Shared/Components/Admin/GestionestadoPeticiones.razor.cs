namespace BlazorApp2.Shared.Components.Admin; 

//No se van a permitir modificaciones por razones de consistencia de la app y ajuste de tiempo, en cualquier caso esto se puede cambiar
public class GestionEstadoPeticionesBase: ComponentBase {
    [Inject]
    protected API _api { get; set; }
    public IEnumerable<EstadoCalendarioVacacionesResponse> EstadosDias { get; set; }
    


    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    public void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();



    public RadzenDataGrid<EstadoCalendarioVacacionesResponse> estadoGrid { get; set; }

    protected EstadoCalendarioVacacionesResponse estadoToModify;


    public bool IsLoading = false;

    protected override async Task OnInitializedAsync() {
        await LoadData();
    }


    public async Task LoadData() {
        IsLoading = true;
        this.EstadosDias = await _api.GetAllEstadoCalendarioVacacionesAsync();
        IsLoading = false;
    }


    protected async Task OnUpdateRow(EstadoCalendarioVacacionesResponse estado) {


        //if (estado == estadoToModify) {

        //    estadoToModify = null;
        //}
        //UpdateEstad u = MapFrom<RolesResponse, UpdateRolesCommand>.Map(estado);
        //await _api.UpdateRolesAsync(u);


        //await LoadData();

    }

    public async Task SaveRow(EstadoCalendarioVacacionesResponse estado) {
        //if (insercion && validarRoles(estado)) {
        //    CreateRolesCommand c = MapFrom<RolesResponse, CreateRolesCommand>.Map(estado);
        //    await _api.CreateRolesAsync(c);
        //    await LoadData();
        //    insercion = false;
        //}
        //else await estadoGrid.UpdateRow(estado);
    }

    public bool validarEstado(EstadoCalendarioVacacionesResponse order) {
        return order.Id != 0;
    }

    //si hay ediciones cambiar esto
    public void CancelEdit(RolesResponse order) {
        throw new NotImplementedException();

        //if (order == estadoToModify) estadoToModify = null;
        //estadoGrid.CancelEditRow(order);
    }
    //si se permiten eliminaciones cambiar
    public async Task DeleteRow(EstadoCalendarioVacacionesResponse estado) {
        throw new NotImplementedException();
        //if (estado == estadoToModify) estadoToModify = null;


        //if (EstadosDias.Contains(estado)) {
        //    DeleteRolesCommand d = MapFrom<EstadoCalendarioVacacionesResponse, DeleteRolesCommand>.Map(estado);
        //    await _api.DeleteRolesAsync(d);

        //    await LoadData();
        //    StateHasChanged();
        //}
        //else {
        //    estadoGrid.CancelEditRow(estado);
        //}

    }
    public bool insercion = false;

    protected async Task InsertRow() {
        throw new NotImplementedException();
        //insercion = true;
        //this.estadoToModify = new EstadoCalendarioVacacionesResponse();
        //estadoToModify.Id = this.EstadosDias.Max(X => X.Id) + 1;

        //await estadoGrid.InsertRow(estadoToModify);
    }

    protected async Task EditRow(RolesResponse rol) {
        throw new NotImplementedException();
        //this.estadoToModify = rol;
        //await estadoGrid.EditRow(rol);
    }
    protected async Task OnCreateRow(EstadoCalendarioVacacionesResponse order) {
        throw new NotImplementedException();

        //CreateEs c = MapFrom<RolesResponse, CreateRolesCommand>.Map(order);
        //await _api.CreateRolesAsync(c);
    }


}
