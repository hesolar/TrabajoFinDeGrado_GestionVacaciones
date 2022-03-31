using System;

namespace Core.Entities;
public class TecnicoProyectos {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdTecnicoProyecto { get; set; }
    public int IdTecnico { get; set; }
    public int Proyecto { get; set; }
    public string Observaciones { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime? FechaHasta { get; set; }

   
}

