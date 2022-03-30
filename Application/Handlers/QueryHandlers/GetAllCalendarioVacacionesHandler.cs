namespace Application.Handlers.QueryHandlers;

public class GetAllCalendarioVacacionesHandler : IRequestHandler<GetAllCalendarioVacacionesQuery, IEnumerable<CalendarioVacacionesResponse>> {
    private readonly ICalendarioVacacionesRepository _repository;

    public GetAllCalendarioVacacionesHandler(ICalendarioVacacionesRepository calendarioVacacionesRepository) {
        _repository = calendarioVacacionesRepository;
    }
    public async Task<IEnumerable<CalendarioVacacionesResponse>> Handle(GetAllCalendarioVacacionesQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.CalendarioVacaciones> calendarioVacacionesEntities = await _repository.GetAllAsync();
        return MapperBase<CalendarioVacacionesMappingProfile,CalendarioVacacionesResponse>.MappIEnumerable(calendarioVacacionesEntities);
    }
}
