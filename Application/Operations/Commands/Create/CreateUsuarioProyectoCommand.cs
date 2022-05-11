namespace Application.Operations.Commands;

public class CreateUsuarioProyectoCommand : IRequest<bool> {
    public int IdTecnico { get; set; }
    public int IdProyecto { get; set; }

}
