namespace Application.Operations.Commands;
public class DeleteUsuarioCommand : IRequest<bool> {
    public int IdTecnico { get; set; }
}
