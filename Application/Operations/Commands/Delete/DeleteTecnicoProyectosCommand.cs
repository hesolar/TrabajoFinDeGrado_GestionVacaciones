namespace Application.Operations.Commands;


public class DeleteTecnicoProyectosCommand : IRequest<bool> {

    public int TecnicoProyectoId { get; set; }


}
