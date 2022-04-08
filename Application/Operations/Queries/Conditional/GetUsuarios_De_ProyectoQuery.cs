namespace Application.Operations.Queries;
public class GetUsuarios_De_ProyectoQuery: IRequest<IEnumerable<int>> {
    public int Proyecto { get; set; }
}
