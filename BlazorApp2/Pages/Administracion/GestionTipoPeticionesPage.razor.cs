namespace BlazorApp2.Pages.Administracion;
public class GestionTipoPeticionesPageBase : ComponentBase {

    [Inject]
    public API _api { get; set; }

    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
    public void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();

    public IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
    public IEnumerable<TipoDiaCalendarioResponse> TiposDias { get; set; }
    public RadzenDataGrid<TipoDiaCalendarioResponse> TipoDiaGrid { get; set; }

    protected TipoDiaCalendarioResponse TipoDiaToModify;


    public bool IsLoading = false;



    protected override async Task OnInitializedAsync() {
        IsLoading = true;
        await LoadData();
        IsLoading = false;
    }

    public async Task LoadData() {
        this.UsuariosAplicacion = await _api.GetAllUsuariosAsync();
        this.TiposDias = await _api.GetAllTipoDiaCalendarioAsync();
    }


    protected async Task OnUpdateRow(TipoDiaCalendarioResponse order) {


        if (order == TipoDiaToModify) {

            TipoDiaToModify = null;
        }
        //UpdateTipoDia u = MapFrom<TipoDiaesResponse, UpdateTipoDiaesCommand>.Map(order);
        //await _api.UpdateTipoDiaesAsync(u);
        //todo

        await LoadData();

    }

    public async Task SaveRow(TipoDiaCalendarioResponse tipoDia) {
        if (insercion && validarTipoDia(tipoDia)) {
            CreateTipoDiaCalendarioCommand c = MapFrom<TipoDiaCalendarioResponse, CreateTipoDiaCalendarioCommand>.Map(tipoDia);

           
            await _api.CreateTipoDiaCalendarioAsync(c);
            await LoadData();
            insercion = false;
        }
        else {
            UpdateTipoDiaCalendarioCommand command = MapFrom<TipoDiaCalendarioResponse,UpdateTipoDiaCalendarioCommand>.Map(tipoDia);
            await _api.UpdateTipoDiaCalendarioAsync(command);
            await TipoDiaGrid.UpdateRow(tipoDia);
        }
    }

    public bool validarTipoDia(TipoDiaCalendarioResponse tipoDia) {
        return true;
        //return !string.IsNullOrEmpty(tipoDia.TipoDia) && tipoDia.Id > 0;
    }

    public void CancelEdit(TipoDiaCalendarioResponse tipoDia) {
        if (tipoDia == TipoDiaToModify) TipoDiaToModify = null;
        TipoDiaGrid.CancelEditRow(tipoDia);
    }

    public async Task DeleteRow(TipoDiaCalendarioResponse tipoDia) {
        if (tipoDia == TipoDiaToModify) TipoDiaToModify = null;


        
         DeleteTipoDiaCalendarioCommand d = MapFrom<TipoDiaCalendarioResponse, DeleteTipoDiaCalendarioCommand>.Map(tipoDia);
        await _api.DeleteTipoDiaCalendarioAsync(d);
        await LoadData();
        StateHasChanged();

        

    }
    public bool insercion = false;

    protected async Task InsertRow() {
        insercion = true;
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