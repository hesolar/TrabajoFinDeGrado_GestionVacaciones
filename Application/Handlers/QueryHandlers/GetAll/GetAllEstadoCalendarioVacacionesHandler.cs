namespace Application.Handlers.QueryHandlers;

public class GetAllEstadoCalendarioVacacionesHandler : IRequestHandler<GetAllEstadoCalendarioVacacionesQuery, IEnumerable<EstadoCalendarioVacacionesResponse>> {
    private readonly IEstadoCalendarioVacacionesRepository _repository;

    public GetAllEstadoCalendarioVacacionesHandler(IEstadoCalendarioVacacionesRepository EstadoCalendarioVacacionesRepository) {
        _repository = EstadoCalendarioVacacionesRepository;
    }
    public async Task<IEnumerable<EstadoCalendarioVacacionesResponse>> Handle(GetAllEstadoCalendarioVacacionesQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.EstadoCalendarioVacaciones> EstadoCalendarioVacacionesEntities = await _repository.GetAllAsync();
        return MapperBase<EstadoCalendarioVacacionesMappingProfile,EstadoCalendarioVacacionesResponse>.MappIEnumerable(EstadoCalendarioVacacionesEntities);
    }
}
