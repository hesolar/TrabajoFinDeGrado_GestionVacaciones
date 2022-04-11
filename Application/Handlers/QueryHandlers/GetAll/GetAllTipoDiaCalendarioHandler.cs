namespace Application.Handlers.QueryHandlers;

public class GetAllTipoDiaCalendarioHandler : IRequestHandler<GetAllTipoDiaCalendarioQuery, IEnumerable<TipoDiaCalendarioResponse>>
{
    private readonly ITipoDiaCalendarioRepository _repository;

    public GetAllTipoDiaCalendarioHandler(ITipoDiaCalendarioRepository TipoDiaCalendarioRepository){
        _repository = TipoDiaCalendarioRepository;
    }
    public async Task<IEnumerable<TipoDiaCalendarioResponse>> Handle(GetAllTipoDiaCalendarioQuery request, CancellationToken cancellationToken){
        IReadOnlyList<Core.Entities.TipoDiaCalendario> TipoDiaCalendarios = await _repository.GetAllAsync();
        var mapeo = MapperBase<TipoDiaCalendarioMappingProfile, TipoDiaCalendarioResponse>.MappIEnumerable(TipoDiaCalendarios);
        return mapeo;
    }
}