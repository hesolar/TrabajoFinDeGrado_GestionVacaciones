namespace Application.Handlers.CommandHandlers;

public class CreateTipoDiaCalendarioHandler : IRequestHandler<CreateTipoDiaCalendarioCommand, bool> {
    private readonly ITipoDiaCalendarioRepository _TipoDiaRepo;

    public CreateTipoDiaCalendarioHandler(ITipoDiaCalendarioRepository TipoDiaRepository) {
        _TipoDiaRepo = TipoDiaRepository;
    }
    public async Task<bool> Handle(CreateTipoDiaCalendarioCommand request, CancellationToken cancellationToken) {
        Core.Entities.TipoDiaCalendario TipoDiaEntitiy = MapperBase<TipoDiaCalendarioMappingProfile, Core.Entities.TipoDiaCalendario>.MappEntity(request);
        if (TipoDiaEntitiy is null) throw new ApplicationException("Issue with mapper");
        return await _TipoDiaRepo.AddAsync(TipoDiaEntitiy);
    }
}
