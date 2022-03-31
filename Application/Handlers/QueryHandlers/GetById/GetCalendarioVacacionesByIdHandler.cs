namespace Application.Operations.Queries;

public class GetCalendarioVacacionesByIdHandler : IRequestHandler<GetCalendarioVacacionesByIdQuery, CalendarioVacacionesResponse> {
    private readonly ICalendarioVacacionesRepository _repository;
    public GetCalendarioVacacionesByIdHandler(ICalendarioVacacionesRepository employeeRepository) {
        _repository = employeeRepository;
    }
    public async Task<CalendarioVacacionesResponse> Handle(GetCalendarioVacacionesByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.CalendarioVacaciones calendarioVacaciones = await _repository.GetByIdAsync(Tuple.Create(request.IdTecnico, request.Fecha));
        return MapperBase<CalendarioVacacionesMappingProfile, CalendarioVacacionesResponse>.MappEntity(calendarioVacaciones);
    }
}



