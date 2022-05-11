namespace Application.Operations.Commands;
public class DeleteUsuarioProyectoCommand : IRequest<bool> {
    public int IdTecnico { get; set; }
    public int IdProyecto { get; set; }
}
