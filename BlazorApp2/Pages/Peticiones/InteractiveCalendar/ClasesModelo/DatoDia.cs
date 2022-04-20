using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Pages.Peticiones.InteractiveCalendar;
public class DatoDia {
    #region constructor
    public DatoDia(DateTime d) {
        //todo
        //this.Estado = (d.DayOfWeek.ToString().ToLower() is "saturday" or "sunday") ? "Festividad" : "Laborable";
        this.Estado = "Laborable";
        this.Date = d;
    }
    #endregion

    #region properties
    [Key]
    public DateTime Date { get; set; }
    public String Estado { get; set; }
    public String ColorSeleccion { get; set; } = "none";
    #endregion
}

//Encapsular dias para no repetirlos
public class DatosDias : KeyedCollection<DateTime, DatoDia> {
    public DatosDias(IEnumerable<DatoDia> dias) => dias.ToList().ForEach(dia => this.Items.Add(dia));
    protected override DateTime GetKeyForItem(DatoDia item) => item.Date;
}