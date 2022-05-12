namespace BlazorApp2.Pages.Gestion.CalendarioEquipo;
public class Calendario {
    public int AñoCalendario { get; set; }= DateTime.Now.Year;
    public DatosDias DiasCalendario { get; set; } = new(new List<DatoDia>());
    public static readonly int TotalHolidayDays = 30;
}





