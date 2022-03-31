namespace Application.Operations.Queries;

public class GetCalendarioVacacionesByIdQuery : IRequest<CalendarioVacacionesResponse> {
    public int IdTecnico { get; set; }
    public DateTime Fecha { get; set; }
}


