
namespace Application.Operations.Queries;


public class GetProyectoByIdQuery : IRequest<ProyectoResponse> {
    public int IdProyecto { get; set; }
}
