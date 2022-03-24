
namespace Core.Entities;
public class CalendarioVacaciones {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTecnico { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FechaCalendario{get; set;}
    public int tipoDiaCalendario { get; set; } = 0;
    public String TipoDiaCalendario {get; set;}
}

