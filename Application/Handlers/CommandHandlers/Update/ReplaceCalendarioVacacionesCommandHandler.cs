namespace Application.Handlers.CommandHandlers;

public class ReplaceCalendarioVacacionesCommandHandler : IRequestHandler<ReplaceCalendarioVacacionesCommand, bool> {
    private readonly ICalendarioVacacionesRepository _repository;

    public ReplaceCalendarioVacacionesCommandHandler(ICalendarioVacacionesRepository employeeRepository) {
        _repository = employeeRepository;
    }

    public async Task<bool> Handle(ReplaceCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        CalendarioVacacionesResponse newEntity = new CalendarioVacacionesResponse() {
            IdTecnico = request.IdTecnico,
            FechaCalendario = request.FechaCalendarioNew,
            TipoDiaCalendario = request.TipoDiaCalendarioNew
        };
        Core.Entities.CalendarioVacaciones newCoreEntity=  MapperBase<CalendarioVacacionesMappingProfile,Core.Entities.CalendarioVacaciones>.MappEntity(newEntity);

        var KeyOldEntity = Tuple.Create(request.IdTecnico, request.FechaCalendarioOld);
        await _repository.DeleteAsync(KeyOldEntity);
        return await _repository.AddAsync(newCoreEntity);
    }


}
