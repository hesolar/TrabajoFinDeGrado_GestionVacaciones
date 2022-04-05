namespace Application.Handlers.QueryHandlers;

public class GetCalendarioVacacionesUsuarioHandler : IRequestHandler<GetCalendarioVacacionesUsuarioQuery, IEnumerable<CalendarioVacacionesResponse>> {
    private readonly ICalendarioVacacionesRepository _repository;

    public GetCalendarioVacacionesUsuarioHandler(ICalendarioVacacionesRepository calendarioVacacionesRepository) {
        _repository = calendarioVacacionesRepository;
    }
    public async Task<IEnumerable<CalendarioVacacionesResponse>> Handle(GetCalendarioVacacionesUsuarioQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.CalendarioVacaciones> calendarioVacacionesEntities = await _repository.GetDiaUsuario(request.Id);
        return MapperBase<CalendarioVacacionesMappingProfile,CalendarioVacacionesResponse>.MappIEnumerable(calendarioVacacionesEntities);
    }
}
