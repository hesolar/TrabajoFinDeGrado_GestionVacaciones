namespace BlazorApp2.Pages.PeticionesPropias; 
public class PeticionesPageBase: ComponentBase {
    
    
    [Inject] 
    protected  API _api { get; set; }
    public IEnumerable<TipoDiaCalendarioResponse> ColoresBotones { get; set; } = new List<TipoDiaCalendarioResponse>();
    protected RadzenCard TarjetaPeticionesPropias = new();
    protected RadzenCard TarjetaCalendario = new();

    protected override async Task OnInitializedAsync() {
        var estados = await _api.GetAllEstadoCalendarioVacacionesAsync();
        ColoresBotones = await _api.GetAllTipoDiaCalendarioAsync();
        StateHasChanged();
    }

    public async Task RefreshCalendar() {
        this.TarjetaCalendario.Visible = false;
        StateHasChanged();
        this.TarjetaCalendario.Visible = true;
        StateHasChanged();

    }
}
