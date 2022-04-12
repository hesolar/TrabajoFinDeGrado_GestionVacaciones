namespace Cal;
public class Calendario {
    #region constructors
    public Calendario() {
        this.AñoCalendario = DateTime.Now.Year;
        this.DiasCalendario = new(new List<DatoDia>());
    }
    public Calendario(int year) {
        this.AñoCalendario = year;
        this.DiasCalendario = new(new List<DatoDia>());
    }
    //todo cuando tenga requerimientos
    public Calendario(DatosDias DiasCalendario, int totalDiasVacaciones) {
        this.AñoCalendario = DiasCalendario.First().Date.Year;
        this.DiasCalendario = DiasCalendario;
        //todo Calendario.TotalHolidayDays = totalDiasVacaciones;
    }
    #endregion


    #region properties
    public int AñoCalendario { get; set; }
    public DatosDias DiasCalendario { get; set; }
    public static readonly int TotalHolidayDays = 30;
    public static readonly int DaysMaxToWork = 100;
    #endregion
}





