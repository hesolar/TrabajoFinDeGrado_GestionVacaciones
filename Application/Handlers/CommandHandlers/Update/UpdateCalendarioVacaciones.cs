
namespace Application.Handlers.CommandHandlers;

public class UpdateCalendarioVacaciones : IRequestHandler<UpdateCalendarioVacacionesCommand, bool> {
    private readonly ICalendarioVacacionesRepository _repostory;

    public UpdateCalendarioVacaciones(ICalendarioVacacionesRepository employeeRepository) {
        _repostory = employeeRepository;
    }

    public async Task<bool> Handle(UpdateCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        Core.Entities.CalendarioVacaciones newEntity= MapperBase<CalendarioVacacionesMappingProfile, Core.Entities.CalendarioVacaciones>.MappEntity(request);
        //var oldEntity  = await _repostory.GetByIdAsync(Tuple.Create(newEntity.IdTecnico, newEntity.FechaCalendario));
        return await _repostory.UpdateAsync(newEntity);       
        //return await _repostory.ReplaceAsync(newEntity,oldEntity);
    }


}


