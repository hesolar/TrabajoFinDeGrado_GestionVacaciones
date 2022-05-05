namespace BlazorApp2.Shared.Components.Admin;
public class ProyectosGridBase : ComponentBase {

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    public void RecoverAppState() =>ErrorBoundaryInsercionesNomodificaciones.Recover();
    

    [Parameter]
    public IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    [Parameter]
    public API _api { get; set; }
    [Parameter]
    public RadzenDataGrid<ProyectoResponse> ordersGrid { get; set; }

    protected ProyectoResponse orderToModify;


    public IEnumerable<ProyectoResponse> Proyectos;

    public bool IsLoading = false;



    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        await LoadData();
        IsLoading = false;
    }

    public async Task LoadData() {
        var total = await _api.GetAllProyectosAsync();

        this.Proyectos = total.Where(X => X.Nombre != "ProyectoInicial");

    }


    protected async Task OnUpdateRow(ProyectoResponse order) {


        if (order == orderToModify) {

            orderToModify = null;
        }
        UpdateProyectoCommand u = MapFrom<ProyectoResponse, UpdateProyectoCommand>.Map(order);
        await _api.UpdateProyectoAsync(u);


        await LoadData();

    }

    public async Task SaveRow(ProyectoResponse order) {
        if (insercion && validarProyecto(order)) {
            CreateProyectoCommand c = MapFrom<ProyectoResponse, CreateProyectoCommand>.Map(order);
            await _api.CreateProyectoAsync(c);
            await LoadData();
            insercion = false;
        }
        else await ordersGrid.UpdateRow(order);
    }

    public bool validarProyecto(ProyectoResponse order) {
        return !string.IsNullOrEmpty(order.Nombre) && !string.IsNullOrEmpty(order.Descripcion) && order.IdManager > 0;
    }

    public void CancelEdit(ProyectoResponse order) {
        if (order == orderToModify) orderToModify = null;
        ordersGrid.CancelEditRow(order);
    }

    public async Task DeleteRow(ProyectoResponse order) {
        if (order == orderToModify) orderToModify = null;


        if (Proyectos.Contains(order)) {
            DeleteProyectoCommand d = MapFrom<ProyectoResponse, DeleteProyectoCommand>.Map(order);
            await _api.DeleteProyectoAsync(d);

            await LoadData();
            StateHasChanged();
        }
        else {
            ordersGrid.CancelEditRow(order);
        }
    }
    public bool insercion = false;

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

