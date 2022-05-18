namespace BlazorApp2.Pages.PeticionesPropias; 
public class PeticionesPageBase: ComponentBase {    
    [Inject] protected  API _api { get; set; }
    protected IEnumerable<TipoDiaCalendarioResponse> ColoresBotones { get; set; } = new List<TipoDiaCalendarioResponse>();
    protected RadzenCard TarjetaPeticionesPropias = new(); 
    protected RadzenCard TarjetaCalendario = new();

    /// <summary>
    /// Cargar estados y tipos de botones de la página
    /// </summary>
    /// <returns></returns>
    protected override async Task OnInitializedAsync() {
        var estados = await _api.GetAllEstadoCalendarioVacacionesAsync();
        ColoresBotones = await _api.GetAllTipoDiaCalendarioAsync();
        StateHasChanged();
    }
    /// <summary>
    /// Recargar el calendario cuando ha habido cambios
    /// </summary>
    /// <returns></returns>
    public async Task RefreshCalendar() {
        this.TarjetaCalendario.Visible = false;
        StateHasChanged();
        this.TarjetaCalendario.Visible = true;
    }
}
