namespace Application.Handlers.CommandHandlers;

public class UpdateTipoDiaCalendarioHandler : IRequestHandler<UpdateTipoDiaCalendarioCommand, bool> {
    private readonly ITipoDiaCalendarioRepository _repostory;

    public UpdateTipoDiaCalendarioHandler(ITipoDiaCalendarioRepository TipoDiaCalendarioRepository) {
        _repostory = TipoDiaCalendarioRepository;
    }

    public async Task<bool> Handle(UpdateTipoDiaCalendarioCommand request, CancellationToken cancellationToken) {
        
        Core.Entities.TipoDiaCalendario TipoDiaCalendarioEntitiy = MapperBase<TipoDiaCalendarioMappingProfile,Core.Entities.TipoDiaCalendario>.MappEntity(request);
        return await _repostory.UpdateAsync(TipoDiaCalendarioEntitiy);
         
    }


}


