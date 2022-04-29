using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp2.Shared.Components.Vacaciones;



public class DatoDia {
    #region constructor
    public DatoDia(DateTime d) {
        //todo
        this.TipoDia = (d.DayOfWeek.ToString().ToLower() is "saturday" or "sunday") ? "Disabled" : "Laborable";
        this.Date = d;
    }
    #endregion

    #region properties
    [Key]
    public DateTime Date { get; set; }
    public String TipoDia { get; set; }
    public String Estado { get; set; } = "";
    public String ColorSeleccion { get; set; } = "none";
    #endregion


}

//Encapsular dias para no repetirlos
public class DatosDias : KeyedCollection<DateTime, DatoDia> {
    public DatosDias(IEnumerable<DatoDia> dias) => dias.ToList().ForEach(dia => this.Items.Add(dia));
    protected override DateTime GetKeyForItem(DatoDia item) => item.Date;
    public override bool Equals(object? obj) {
        if (obj == null) return false;
        DatosDias diasComparar = obj as DatosDias;
        for (int i = 0; i < diasComparar.Items.Count; i++) {
            var a = this.Items[i];
            var b = diasComparar.Items[i];
            if (a.TipoDia != b.TipoDia) {
                return false;
            }
        }
        return true;
    }

 
}
