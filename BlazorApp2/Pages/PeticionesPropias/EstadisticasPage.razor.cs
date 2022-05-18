

namespace BlazorApp2.Pages.PeticionesPropias;
public class EstadisticasPageBase : ComponentBase {
    [Parameter] public UsuarioResponse? usuarioApp { get; set; }

    [Inject] protected API _api{get;set;}
    [Inject] protected AuthenticationStateProvider _authenticationStateprovider{get;set;}
    [Inject] protected TooltipService tooltipService{get;set;}


    protected IEnumerable<ColorScheme> colorSchemes = Enum.GetValues(typeof(ColorScheme)).Cast<ColorScheme>();
    protected int YearSeleccionado = DateTime.Now.Year;
    protected ColorScheme colorScheme = ColorScheme.Pastel;
    protected ICollection<CalendarioVacacionesResponse> datos;
    protected ICollection<TipoDiaCalendarioResponse> TiposDias;
    protected ICollection<EstadoCalendarioVacacionesResponse> EstadosDias;
    protected UsuarioResponse usuario;


    protected override async Task OnInitializedAsync() {
        this.usuario = ObtenerUsuarioEnAplicacion();
        this.EstadosDias = await _api.GetAllEstadoCalendarioVacacionesAsync();
        this.TiposDias = await _api.GetAllTipoDiaCalendarioAsync();
        var datosRecibidos = await _api.GetUsuarioCalendarioVacacionesAsync(usuario.IdTecnico);
        if (datosRecibidos!=null && datosRecibidos.Any()) this.datos = datosRecibidos.ToList();
        StateHasChanged();
    }

    public UsuarioResponse ObtenerUsuarioEnAplicacion() 
        => usuarioApp != null ? usuarioApp : 
                                _authenticationStateprovider.GetCurrentUser(_api);
    
}
