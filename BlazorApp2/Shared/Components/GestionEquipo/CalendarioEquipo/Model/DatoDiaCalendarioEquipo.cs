using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace BlazorApp2.Pages.Gestion.CalendarioEquipo;
public class DatoDiaCalendarioEquipo {
    #region constructor
    public DatoDiaCalendarioEquipo(DateTime d,int usuariosTrabajando) {
        //todo
        this.TipoDia = (d.DayOfWeek.ToString().ToLower() is "saturday" or "sunday") ? "Disabled" : "Laborable";
        this.Date = d;
        this.usuariosDeVacaciones = usuariosTrabajando;
    }
    #endregion

    #region properties
    [Key]
    public DateTime Date { get; set; }
    public String TipoDia { get; set; }
    public String ColorSeleccion { get; set; } = "none"; 
    public int usuariosDeVacaciones { get; set; }
    #endregion


}

//Encapsular dias para no repetirlos
public class DatosDias : KeyedCollection<DateTime, DatoDiaCalendarioEquipo> {
    public DatosDias(IEnumerable<DatoDiaCalendarioEquipo> dias) => dias.ToList().ForEach(dia => this.Items.Add(dia));
    protected override DateTime GetKeyForItem(DatoDiaCalendarioEquipo item) => item.Date;
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
