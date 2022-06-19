namespace Application.Handlers.CommandHandlers;
public class DeleteTipoDiaCalendarioHandler : IRequestHandler<DeleteTipoDiaCalendarioCommand,bool> {
    private ITipoDiaCalendarioRepository _context;
    public DeleteTipoDiaCalendarioHandler(ITipoDiaCalendarioRepository context) => this._context = context;
    public async Task<bool> Handle(DeleteTipoDiaCalendarioCommand request, CancellationToken cancellationToken) {
        
        
        
        Core.Entities.TipoDiaCalendario TipoDiaCalendarioEntitiy = MapperBase<TipoDiaCalendarioMappingProfile, Core.Entities.TipoDiaCalendario>.MappEntity(request);
        if (TipoDiaCalendarioEntitiy is null)  throw new ApplicationException("Issue with mapper");
        return await _context.DeleteByIdAsync(request.Id);
    }
}

