using System.Drawing;

namespace BlazorApp2.Pages.Gestion.CalendarioEquipo;
public class CalendarioEquipoBase : ComponentBase {
    #region variables principales

    //Dias Calendario
    public DatosDias diasCalendario;

    [Parameter]
    public Dictionary<CalendarioVacacionesResponse, int> totalDias { get; set; }

    [Parameter]
    public int TotalUsuarios { get; set; }
    //Api proyecto
    [Inject]
    protected API _api { get; set; }

    //Gestión Sesión, usuario actual
    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }

    /// <summary>
    /// Se cargan los datos de la bd: (dias y sus estado) , finalmente se llama al método para actualizar el calendario
    /// </summary>
    /// <param name="firstRender">primer renderizado de la app</param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender) {
        //Si es first render es decir que es la primera vez que se carga la página
        if (firstRender) { 
            ActualizarDiasCalendario();         
            StateHasChanged();
        }
        
    }

    /// <summary>
    /// Dado un conjunto de vacaciones y sus estados se actualiza el calendario, se marca también el estado inicial del calendario para poder comparar si suestado cambio
    /// </summary>
    /// <param name="vacaciones"></param>
    /// <param name="tiposDias"></param>
    /// <returns></returns>
    public void ActualizarDiasCalendario() {
        this.diasCalendario = GenerarDatosCalendario();
        StateHasChanged();
    }

    /// <summary>
    /// Genera los dias de un calendario con los datos que llegan desde la BD
    /// </summary>
    /// <param name="datosCalendario">dia</param>
    /// <param name="vacaciones">vacaciones desde la BD</param>
    /// <param name="tiposDias">Tipos de dias encontrados</param>
    public DatosDias GenerarDatosCalendario() {
        DatosDias datosCalendario;
        datosCalendario = OperacionesCalendario.GenerarDiasCalendario(DateTime.Now.Year);
        this.totalDias.Keys.ToList().ForEach(x => {
            DatoDiaCalendarioEquipo dia = datosCalendario.FirstOrDefault(y => x.FechaCalendario.Date == y.Date);
            if (dia != null) {
                dia.usuariosDeVacaciones = totalDias[x];
                double d = (double)dia.usuariosDeVacaciones / (double) this.TotalUsuarios * 100;
                int total = 100 - (int)Math.Round(d);
                var color = GetBlendedColor(total);
                dia.ColorSeleccion = ColorTranslator.ToHtml(color);
            }
        });
        var xxxxxxx = 3;
        return datosCalendario;
    }

    Color GetBlendedColor(int percentage) {
        if (percentage < 50)
            return Interpolate(Color.Red, Color.Yellow, percentage / 50.0);
        return Interpolate(Color.Yellow, Color.Lime, (percentage - 50) / 50.0);
    }
    Color Interpolate(Color color1, Color color2, double fraction) {
        double r = Interpolate2(color1.R, color2.R, fraction);
        double g = Interpolate2(color1.G, color2.G, fraction);
        double b = Interpolate2(color1.B, color2.B, fraction);
        return Color.FromArgb((int)Math.Round(r), (int)Math.Round(g), (int)Math.Round(b));
    }
    double Interpolate2(double d1, double d2, double fraction) {
        return d1 + (d2 - d1) * fraction;
    }



    #endregion
    #region Event Listeners

    /// <summary>
    /// Gestión de selección de dias en función del valor de la multiseleccion
    /// </summary>
    /// <param name="dia"></param>
    public void DaySelectorEventListener(DatoDiaCalendarioEquipo dia) {

        //Dialog
    }

    public void NotifyDayChanges() {
        StateHasChanged();
    }

    #endregion
}
