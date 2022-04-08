namespace Application.Operations.Commands;
public class DeleteUsuarioProyectoCommand : IRequest<bool> {
    public int IdTecnico { get; set; }
    public int Proyecto { get; set; }
}
