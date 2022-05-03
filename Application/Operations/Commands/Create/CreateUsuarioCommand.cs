namespace Application.Operations.Commands;

public class CreateUsuarioCommand : IRequest<bool> 
{
    public string? Nombre { get; set; }
    public string? Apellido1 { get; set; }
    public string? Apellido2 { get; set; }
    public string? NIF { get; set; }
    public string? EmailPersonal { get; set; }
    public string EmailCorporativo { get; set; }
    public string? Direccion { get; set; }
    public string? Telefono1 { get; set; }
    public string? Telefono2 { get; set; }
    public DateTime FechaRegistro { get; set; }
    public DateTime? FechaAltaEmpresa { get; set; }
    public DateTime? FechaBajaEmpresa { get; set; }
    public string? WebContrasena { get; set; }
    public int WebRol { get; set; }
    public int? SeguimientNotificacion { get; set; }
    public DateTime? SeguimientoFecha { get; set; }
    public int? SeguimientoIntervalo { get; set; }
    public decimal? EmpresaTarifa { get; set; }
    public int? EmpresaCategoria { get; set; }
    public string? ClienteCuenta { get; set; }
    public int? ClienteCategoria { get; set; }
    public int? ClienteNivel { get; set; }
    public string? RedmineAPIKey { get; set; }
    public int? RedmineIdProyecto { get; set; }

    public IEnumerable<int> Proyectos { get; set; }

}
