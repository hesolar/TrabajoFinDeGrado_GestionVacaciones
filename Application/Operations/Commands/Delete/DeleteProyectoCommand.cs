namespace Application.Operations.Commands;

public class DeleteProyectoCommand : IRequest<bool> {
    public int IdProyecto { get; set; }    
}
