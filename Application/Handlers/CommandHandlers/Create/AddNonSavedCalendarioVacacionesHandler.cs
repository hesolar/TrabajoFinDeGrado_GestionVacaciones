namespace Application.Handlers.CommandHandlers;
public class AddNonSavedCalendarioVacacionesHandler : IRequestHandler<AddNonSavedCalendarioVacacionesCommand, IEnumerable<CalendarioVacacionesResponse>> {
    private readonly ICalendarioVacacionesRepository _repository;
    public AddNonSavedCalendarioVacacionesHandler(ICalendarioVacacionesRepository calendarioVacacionesRepository) {
        _repository = calendarioVacacionesRepository;
    }
    public async Task<IEnumerable<CalendarioVacacionesResponse>> Handle(AddNonSavedCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        IEnumerable<Core.Entities.CalendarioVacaciones> calendarioVacacionesEntities = MapperBase<CalendarioVacacionesMappingProfile, Core.Entities.CalendarioVacaciones>.MappIEnumerable(request.nuevosDias);
        if (calendarioVacacionesEntities is null) throw new ApplicationException("Issue with mapper");

        IEnumerable<Core.Entities.CalendarioVacaciones> respuesta= await _repository.AddNonSavedItems(calendarioVacacionesEntities);
        
        
        return MapperBase<CalendarioVacacionesMappingProfile, CalendarioVacacionesResponse>.MappIEnumerable(respuesta);
    }
}

