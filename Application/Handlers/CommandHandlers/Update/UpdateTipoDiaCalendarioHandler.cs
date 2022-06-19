namespace Application.Handlers.CommandHandlers;

public class UpdateTipoDiaCalendarioHandler : IRequestHandler<UpdateTipoDiaCalendarioCommand, bool> {
    private readonly ITipoDiaCalendarioRepository _repostory;

    public UpdateTipoDiaCalendarioHandler(ITipoDiaCalendarioRepository TipoDiaCalendarioRepository) {
        _repostory = TipoDiaCalendarioRepository;
    }

    public async Task<bool> Handle(UpdateTipoDiaCalendarioCommand request, CancellationToken cancellationToken) {
        
        Core.Entities.TipoDiaCalendario newEntity = MapperBase<TipoDiaCalendarioMappingProfile,Core.Entities.TipoDiaCalendario>.MappEntity(request);
        Core.Entities.TipoDiaCalendario oldEntity = await _repostory.GetByIdAsync(newEntity.Id);
        return await _repostory.ReplaceAsync(oldEntity,newEntity);
         
    }


}


