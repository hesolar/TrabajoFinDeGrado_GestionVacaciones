
namespace BlazorApp2.Shared.Components.EstadisticasPorMes; 
public class EstadisticasPorMesBase: ComponentBase {
    [Parameter] public ColorScheme colorScheme { get; set; }
    [Parameter] public int YearSeleccionado { get; set; }
    [Parameter] public ICollection<CalendarioVacacionesResponse> calendarios { get; set; }
    [Parameter] public ICollection<TipoDiaCalendarioResponse> TiposDias { get; set; }
    [Parameter] public ICollection<EstadoCalendarioVacacionesResponse> EstadosDias { get; set; }
    [Parameter] public UsuarioResponse rio { get; set; }
    [Parameter] public string EstadoDeseado { get; set; }
   
    protected DatoGrafica[] datosGrafica;

    protected string obtenerNombreMesNumero(int numeroMes) {
        DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
        string nombreMes = formatoFecha.GetMonthName(numeroMes);
        return nombreMes.Substring(0, 3);
    }


    protected override void OnParametersSet() {
        if (calendarios != null) LoadData();
    }
    protected void LoadData() {
        //cargar días aprobados del mes
        List<DatoGrafica> Aprobados = new();
        var calendariosAprobados = calendarios.Where(X => this.EstadosDias.First(y => y.Id == X.Estado).Descripcion == this.EstadoDeseado);
        calendariosAprobados.GroupBy(X => X.FechaCalendario.Month).ToList().ForEach(Y => {
            Aprobados.Add(new DatoGrafica {
                Date = DateTime.Parse($"{this.YearSeleccionado}-{Y.First().FechaCalendario.Month}-01"),
                Total = Y.Count(),
                Nombre = obtenerNombreMesNumero(Y.First().FechaCalendario.Month)
            });
        });
        
        RellenarYOrdenarMesesVacios(Aprobados);
        StateHasChanged();
    }

    //Rellenar los messes vacios con datos con total 0 y ordenarlos
    public void RellenarYOrdenarMesesVacios(List<DatoGrafica> AprobadosSinRellenar) {
        Enumerable.Range(1, 12).ToList().ForEach(mes => {
            if (!AprobadosSinRellenar.Any(X => X.Date.Month == mes)) {
                AprobadosSinRellenar.Add(new DatoGrafica() {
                    Date = DateTime.Parse($"{this.YearSeleccionado}-{mes}-01"),
                    Total = 0,
                    Nombre = obtenerNombreMesNumero(mes)
                });
            }
        });
        datosGrafica = AprobadosSinRellenar.OrderBy(X => X.Date.Month).ToArray();
    }

}
