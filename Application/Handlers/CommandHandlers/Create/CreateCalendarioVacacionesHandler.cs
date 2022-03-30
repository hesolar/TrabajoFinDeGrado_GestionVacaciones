namespace Application.Handlers.CommandHandlers;
public class CreateCalendarioVacacionesHandler : IRequestHandler<CreateCalendarioVacacionesCommand, bool> {
    private readonly ICalendarioVacacionesRepository _repository;   
    public CreateCalendarioVacacionesHandler(ICalendarioVacacionesRepository calendarioVacacionesRepository) {
        _repository = calendarioVacacionesRepository;
    }
    public async Task<bool> Handle(CreateCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        Core.Entities.CalendarioVacaciones calendarioVacacionesEntity = MapperBase<CalendarioVacacionesMappingProfile,Core.Entities.CalendarioVacaciones>.MappEntity(request);
        if (calendarioVacacionesEntity is null) {
            throw new ApplicationException("Issue with mapper");
        }
        return await _repository.AddAsync(calendarioVacacionesEntity);
    }
}

