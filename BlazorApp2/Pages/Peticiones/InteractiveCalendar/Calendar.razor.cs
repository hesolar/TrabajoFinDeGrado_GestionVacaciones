using BlazorApp2;
using Microsoft.AspNetCore.Components;


namespace Cal;
public class CalendarCs : ComponentBase {
    #region variables principales

    public Calendario CalendarioUsuario;
    public DatosDias diasCalendario;
    public Calendario CalendarioEmpresa;
    #endregion

    #region Variables utilizadas con fines "estéticos"
    //Estado de la seleccion

    [CascadingParameter(Name = "EstadoDiaSeleccion")]


    public String EstadoDiaSeleccion { get; set; }


    //Modo multiseleccion de dias
    [CascadingParameter(Name = "Multiseleccion")]
    public bool DayMultiseletionMode {get;set;}

    [Inject]
    protected API _api { get; set; }

    public Dictionary<string, string> EstadoDiaSelecciones;

    public static readonly String colorInicioMultiseleccion = "white";
    public static readonly String colorInicial = "none";
    public static readonly String colorOver = "blue";


    #endregion

   

    public  CalendarCs() {
        OnParametersSetAsync();
        //todo actualizar los dias del calendario de la empresa q sean public holiday
        this.CalendarioUsuario = new();
        this.CalendarioUsuario.DiasCalendario = Core_Calendario.GenerarDiasCalendario(this.CalendarioUsuario.AñoCalendario);
        this.diasCalendario = this.CalendarioUsuario.DiasCalendario;
        //throw new NotImplementedException();
    }



    /// <summary>
    /// Permite seleccionar multiples dias a la vez con el estado de dia actual
    /// </summary>
    /// <param name="diasEnMultiseleccion">Conjunto de dias</param>
    /// <returns></returns>
    public bool SelectMultipleDays(DatosDias diasEnMultiseleccion) {
        if (CanUpdateAllDays(diasEnMultiseleccion)) {
            if (Core_Calendario.TodosDiasFiltro(
                    diasEnMultiseleccion,
                    new Func<DatoDia, bool>(day => Core_Calendario.CanUpdateDay(this.diasCalendario, day, this.EstadoDiaSeleccion)))) {
                Core_Calendario.AplyFilterToDays(diasEnMultiseleccion, new Action<DatoDia>(dia => SingleSelectionDay(dia)));
                Core_Calendario.AplyFilterToDays(diasEnMultiseleccion, new Action<DatoDia>(dia => dia.ColorSeleccion = colorInicial));
                return true;
            }
        }


        return false;
    }
    //todo necesito restricciones de dominio
    /// <summary>
    /// Este metodo cuando esté hecho determinará si se puede actualizar un conjunto de dias
    /// </summary>
    /// <param name="diasEnMultiseleccion"></param>
    /// <returns></returns>
    private static bool CanUpdateAllDays(DatosDias diasEnMultiseleccion) => true;

    /// <summary>
    /// Este medodo permite seleccionar un dia con el estado de dia actual
    /// </summary>
    /// <param name="dia">Dia que se va a seleccionar</param>
    /// <param name="multiseleccion">Indica si el modo multiseleccion está activo</param>
    /// <returns></returns>
    public bool SingleSelectionDay(DatoDia dia, bool multiseleccion = false) {
        if (Core_Calendario.CanUpdateDay(this.diasCalendario, dia, this.EstadoDiaSeleccion)) {
            //Primero limpiar la seleccion anterior(si es que estamos en multiseleccion)
            if (!multiseleccion) {
                dia.Estado = this.EstadoDiaSeleccion;
                dia.ColorSeleccion = this.EstadoDiaSelecciones[this.EstadoDiaSeleccion];
                //Core_Calendario.AplyFilterToDays(this.diasCalendario, new(dia => dia.Estado = this.EstadoDiaSeleccion));
            }
            //Actualizar el calendario , si es posible retorno true
            return Core_Calendario.ActualizarCalendario(this.diasCalendario, dia, EstadoDiaSeleccion);
        }
        //no se puede seleccioanr el dia con ese estado
        return false;
    }

}







