namespace BlazorApp2.Pages.Peticiones.InteractiveCalendar;
public class Calendario {
    public int AñoCalendario { get; set; }= DateTime.Now.Year;
    public DatosDias DiasCalendario { get; set; } = new(new List<DatoDia>());
    public static readonly int TotalHolidayDays = 30;
}





