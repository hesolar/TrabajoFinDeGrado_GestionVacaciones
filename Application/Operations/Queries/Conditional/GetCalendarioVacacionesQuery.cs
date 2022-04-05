namespace Application.Operations.Queries;
public class GetCalendarioVacacionesUsuarioQuery: IRequest<IEnumerable<CalendarioVacacionesResponse>> {
    public int Id { get; set; }
}
