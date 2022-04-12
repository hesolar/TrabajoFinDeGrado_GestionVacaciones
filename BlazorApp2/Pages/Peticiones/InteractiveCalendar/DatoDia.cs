using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Cal;
public class DatoDia {
    #region constructor
    public DatoDia(DateTime d) {
        //todo pasar a enum
        this.Estado = (d.DayOfWeek.ToString().ToLower() is "saturday" or "sunday") ? EstadoDia.FreeHoliday : EstadoDia.Work;
        this.Date = d;
    }

    [Key]
    public DateTime Date { get; set; }
    #endregion
    #region properties
    public EstadoDia Estado { get; set; }
    //Permite ver si el boton está siendo seleccionado en una multiseleccion
    public String ColorSeleccion { get; set; } = "none";
    #endregion
}

public class DatosDias : KeyedCollection<DateTime, DatoDia> {
    public DatosDias(IEnumerable<DatoDia> dias) => dias.ToList().ForEach(dia => this.Items.Add(dia));
    protected override DateTime GetKeyForItem(DatoDia item) => item.Date;
}