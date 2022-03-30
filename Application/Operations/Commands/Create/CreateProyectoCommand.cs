﻿namespace Application.Operations.Commands;

public class CreateProyectoCommand : IRequest<bool> {
    public int IdProyecto { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public DateTime FechaDesde { get; set; }
    public DateTime? FechaHasta { get; set; }
    public int IdManager { get; set; }

}
