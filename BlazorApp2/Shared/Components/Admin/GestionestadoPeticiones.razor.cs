namespace BlazorApp2.Shared.Components.Admin; 

//No se van a permitir modificaciones por razones de consistencia de la app y ajuste de tiempo, en cualquier caso esto se puede cambiar
public class GestionEstadoPeticionesBase: ComponentBase {
    [Inject] protected API _api { get; set; }
    protected IEnumerable<EstadoCalendarioVacacionesResponse> EstadosDias { get; set; }
    protected bool insercion = false;
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();
    protected RadzenDataGrid<EstadoCalendarioVacacionesResponse> estadoGrid { get; set; }
    protected EstadoCalendarioVacacionesResponse estadoToModify;
    protected bool IsLoading = false;
    protected override async Task OnInitializedAsync() 
        => await LoadData();
    


    public async Task LoadData() {
        IsLoading = true;
        this.EstadosDias = await _api.GetAllEstadoCalendarioVacacionesAsync();
        IsLoading = false;
    }

}
