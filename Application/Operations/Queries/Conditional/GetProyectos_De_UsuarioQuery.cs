namespace Application.Operations.Queries;
public class GetProyectos_De_UsuarioQuery : IRequest<IEnumerable<int>> {
    public int idTecnico { get; set; }
}
