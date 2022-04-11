using System;

namespace Core.Entities;
public class TipoDiaCalendario {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public String Descripcion { get; set; }
    public String ColorRepresentacion { get; set; }
    public int Festivo{ get; set; }
}
