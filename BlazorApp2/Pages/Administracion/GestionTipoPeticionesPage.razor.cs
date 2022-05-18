namespace BlazorApp2.Pages.Administracion;
public class GestionTipoPeticionesPageBase : ComponentBase {

    [Inject] protected API _api { get; set; }
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    protected IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    protected IEnumerable<TipoDiaCalendarioResponse> TiposDias { get; set; }
    protected RadzenDataGrid<TipoDiaCalendarioResponse> TipoDiaGrid { get; set; }
    protected TipoDiaCalendarioResponse TipoDiaToModify;
    protected bool GridIsLoading = false;

    protected bool InsertarNuevoDato = false;


    protected override async Task OnInitializedAsync() {
        GridIsLoading = true;
        await LoadData();
        GridIsLoading = false;
    }
    protected void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();

    protected async Task LoadData() {
        this.UsuariosAplicacion = await _api.GetAllUsuariosAsync();
        this.TiposDias = await _api.GetAllTipoDiaCalendarioAsync();
    }

    protected async Task OnUpdateRow(TipoDiaCalendarioResponse order) {
        if (order == TipoDiaToModify) TipoDiaToModify = null;
        await LoadData();
    }

    protected async Task SaveRow(TipoDiaCalendarioResponse tipoDia) {
         //inserción
        if (InsertarNuevoDato && validarTipoDia(tipoDia)) {
            CreateTipoDiaCalendarioCommand c = MapFrom<TipoDiaCalendarioResponse, CreateTipoDiaCalendarioCommand>.Map(tipoDia);       
            await _api.CreateTipoDiaCalendarioAsync(c);
            await LoadData();
            InsertarNuevoDato = false;
        }
        //modificación
        else {
            UpdateTipoDiaCalendarioCommand command = MapFrom<TipoDiaCalendarioResponse,UpdateTipoDiaCalendarioCommand>.Map(tipoDia);
            await _api.UpdateTipoDiaCalendarioAsync(command);
            await TipoDiaGrid.UpdateRow(tipoDia);
        }
    }
    //Este método comprobaría si el total de dias del usuario es menor que el que puede coger, de momento no ha sido necesario se queda planteado para ampliaciones del proyecto.
    protected bool validarTipoDia(TipoDiaCalendarioResponse tipoDia) 
        => true;

    protected void CancelEdit(TipoDiaCalendarioResponse tipoDia) {
        if (tipoDia == TipoDiaToModify) TipoDiaToModify = null;
        TipoDiaGrid.CancelEditRow(tipoDia);
    }

    protected async Task DeleteRow(TipoDiaCalendarioResponse tipoDia) {
        if (tipoDia == TipoDiaToModify) TipoDiaToModify = null;      
        DeleteTipoDiaCalendarioCommand d = MapFrom<TipoDiaCalendarioResponse, DeleteTipoDiaCalendarioCommand>.Map(tipoDia);
        await _api.DeleteTipoDiaCalendarioAsync(d);
        await LoadData();
        StateHasChanged();        
    }

    protected async Task InsertRow() {
        InsertarNuevoDato = true;
        this.TipoDiaToModify = new TipoDiaCalendarioResponse();
        int id = _api.GetAllTipoDiaCalendarioAsync().Result.Max(X => X.Id);
        TipoDiaToModify.Id = id + 1;
        await TipoDiaGrid.InsertRow(TipoDiaToModify);
    }

    protected async Task EditRow(TipoDiaCalendarioResponse TipoDia) {
        this.TipoDiaToModify = TipoDia;
        await TipoDiaGrid.EditRow(TipoDia);
    }

}