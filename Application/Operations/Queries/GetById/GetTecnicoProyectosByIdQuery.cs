
namespace Application.Operations.Queries;

public class GetTecnicoProyectosByIdQuery : IRequest<TecnicoProyectosResponse> {
    public int IdProyecto { get; set; }
}

