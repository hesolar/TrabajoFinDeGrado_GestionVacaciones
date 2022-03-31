
namespace Application.Handlers.CommandHandlers;

public class UpdateCalendarioVacaciones : IRequestHandler<UpdateCalendarioVacacionesCommand, bool> {
    private readonly ICalendarioVacacionesRepository _repostory;

    public UpdateCalendarioVacaciones(ICalendarioVacacionesRepository employeeRepository) {
        _repostory = employeeRepository;
    }

    public async Task<bool> Handle(UpdateCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        Core.Entities.CalendarioVacaciones entity= MapperBase<CalendarioVacacionesMappingProfile, Core.Entities.CalendarioVacaciones>.MappEntity(request);
        return await _repostory.UpdateAsync(entity);
    }


}


