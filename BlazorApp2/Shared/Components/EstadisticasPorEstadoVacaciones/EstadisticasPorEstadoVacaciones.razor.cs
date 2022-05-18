namespace BlazorApp2.Shared.Components.EstadisticasPorEstadoVacaciones;
using BlazorApp2.Shared.Components.PeticionesPorEstado.Model;

public class EstadisticasPorEstadoVacacionesBase: ComponentBase {

    [Parameter] public ColorScheme colorScheme { get; set; }
    [Parameter] public int YearSeleccionado { get; set; }
    [Parameter] public ICollection<CalendarioVacacionesResponse> calendarios { get; set; }
    [Parameter] public ICollection<TipoDiaCalendarioResponse> TiposDias { get; set; }
    [Parameter] public ICollection<EstadoCalendarioVacacionesResponse> EstadosDias { get; set; }

    protected List<DatoGrafico> DatosGrafico;
    protected override void OnParametersSet() {
        if (this.calendarios != null) LoadData();
    }

    protected void LoadData() {
        this.DatosGrafico = new();
        this.calendarios.GroupBy(X => X.Estado).Select(X => Tuple.Create(EstadosDias.First(Y => Y.Id == X.Key).Descripcion, X.Count()))
        .ToList().ForEach(tupla =>
            this.DatosGrafico.Add(new DatoGrafico() { EstadoDia = tupla.Item1, TotalDias = tupla.Item2 })
        );
        StateHasChanged();
    }

}

