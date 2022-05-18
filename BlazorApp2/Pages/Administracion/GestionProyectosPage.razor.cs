namespace BlazorApp2.Pages.Administracion.GestionProyecto;
public class GestionProyectosBase : ComponentBase {
    [Inject] public API _api { get; set; }
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    protected RadzenDataGrid<ProyectoResponse> ordersGrid { get; set; }
    protected ProyectoResponse orderToModify;
    protected IEnumerable<ProyectoResponse> Proyectos;
    protected bool IsLoading = false;

    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        await LoadData();
        IsLoading = false;
        this.UsuariosAplicacion = await _api.GetAllUsuariosAsync();
    }
    protected void RecoverAppState() =>ErrorBoundaryInsercionesNomodificaciones.Recover();

    public async Task LoadData() {
        var total = await _api.GetAllProyectosAsync();
        this.Proyectos = total.Where(X => X.Nombre != "ProyectoInicial");
    }


    protected async Task OnUpdateRow(ProyectoResponse order) {
        if (order == orderToModify)  orderToModify = null;
        UpdateProyectoCommand u = MapFrom<ProyectoResponse, UpdateProyectoCommand>.Map(order);
        await _api.UpdateProyectoAsync(u);
        await LoadData();
    }

    protected async Task SaveRow(ProyectoResponse order) {
        if (insercion && validarProyecto(order)) {
            CreateProyectoCommand c = MapFrom<ProyectoResponse, CreateProyectoCommand>.Map(order);
            await _api.CreateProyectoAsync(c);
            await LoadData();
            insercion = false;
        }
        else await ordersGrid.UpdateRow(order);
    }

    protected bool validarProyecto(ProyectoResponse order) 
        =>!string.IsNullOrEmpty(order.Nombre) && !string.IsNullOrEmpty(order.Descripcion) && order.IdManager > 0;

    protected async void CancelEdit(ProyectoResponse order) {
        if (order == orderToModify) orderToModify = null;
        ordersGrid.CancelEditRow(order);
        await LoadData();
    }
    protected async Task DeleteRow(ProyectoResponse order) {
            if (order == orderToModify) orderToModify = null;
            if (Proyectos.Contains(order)) {
                DeleteProyectoCommand d = MapFrom<ProyectoResponse, DeleteProyectoCommand>.Map(order);
                await _api.DeleteProyectoAsync(d);
                await LoadData();
                StateHasChanged();
            }
            else ordersGrid.CancelEditRow(order);       
    }
    protected bool insercion = false;
    protected  async Task InsertRow() {
        insercion = true;
        this.orderToModify = new ProyectoResponse() { FechaDesde = DateTime.Now };
        await ordersGrid.InsertRow(orderToModify);
    }
    protected async Task EditRow(ProyectoResponse order) {
        this.orderToModify = order;
        await ordersGrid.EditRow(order);
    }
    protected async Task OnCreateRow(ProyectoResponse order) {
        CreateProyectoCommand c = MapFrom<ProyectoResponse, CreateProyectoCommand>.Map(order);
        await _api.CreateProyectoAsync(c);
    }
}

