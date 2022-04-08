namespace Application.Operations.Queries;

public class GetSubordinadosQuery : IRequest<IEnumerable<CalendarioVacacionesResponse>>{
    public IEnumerable< int> Proyectos { get; set; }
    public int WebRol{get;set;}
}

