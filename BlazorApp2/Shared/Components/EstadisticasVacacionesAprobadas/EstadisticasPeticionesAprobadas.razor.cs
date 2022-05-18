using BlazorApp2.Shared.Components.EstadisticasPeticionesAprobadas.Model;

namespace BlazorApp2.Shared.Components.EstadisticasVacacionesAprobadas.Model; 
public class EstadisticasPeticionesAprobadasBase: ComponentBase {
    [Inject] protected API _api { get; set; }
    [Inject] protected AuthenticationStateProvider _authenticationStateprovider { get; set; }
    [Parameter] public ColorScheme colorScheme { get; set; }
    [Parameter] public int YearSeleccionado { get; set; }
    [Parameter] public ICollection<CalendarioVacacionesResponse> calendarios { get; set; }
    [Parameter] public ICollection<TipoDiaCalendarioResponse> TiposDias { get; set; }
    [Parameter] public ICollection<EstadoCalendarioVacacionesResponse> EstadosDias { get; set; }
    [Parameter] public UsuarioResponse usuario { get; set; }
    protected IList<DatosGrafico> datosGrafico;

    protected override void OnParametersSet() {
        UsuarioResponse usuario = _authenticationStateprovider.GetCurrentUser(_api);
        if (this.calendarios != null) GenerarDatosGrafico();
    }
    public void GenerarDatosGrafico() {
        this.datosGrafico = new List<DatosGrafico>();
        var CalendarioAgrupadoYear = calendarios.GroupBy(X => X.FechaCalendario.Year);
        foreach (var grupoAnual in CalendarioAgrupadoYear) {
            var grupoPorTipos = grupoAnual.GroupBy(x => x.TipoDiaCalendario);
            foreach (var grupoTipoDia in grupoPorTipos) {

                datosGrafico.Add(new DatosGrafico {
                    Year = grupoTipoDia.First().FechaCalendario.Year,
                    TipoDia = TiposDias.First(x => x.Id == grupoTipoDia.Key).Descripcion,
                    Total = grupoTipoDia.Count(),
                });
            }
        }
        datosGrafico = datosGrafico.OrderBy(x => x.TipoDia).ToList();
        StateHasChanged();
    }
}
