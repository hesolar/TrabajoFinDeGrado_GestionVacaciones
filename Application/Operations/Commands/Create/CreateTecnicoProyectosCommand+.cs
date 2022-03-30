namespace Application.Operations.Commands;

public class CreateTecnicoProyectosCommand : IRequest<bool> {
    public int IdTecnicoProyecto { get; set; }
    public int IdTecnico { get; set; }
    public int Proyecto { get; set; }
    public string Observaciones { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime? FechaHasta { get; set; }
    public string NombreProyecto { get; set; }
    public string Nombre { get; set; }
    public string Apellido1 { get; set; }
    public string Apellido2 { get; set; }
    public int WebRol { get; set; }
    public DateTime? FechaBajaEmpresa { get; set; }

}
