namespace Application.Operations.Queries;

public class GetTipoDiaCalendarioByIdHandler : IRequestHandler<GetTipoDiaCalendarioByIdQuery, TipoDiaCalendarioResponse> {
    private readonly ITipoDiaCalendarioRepository _repository;
    public GetTipoDiaCalendarioByIdHandler(ITipoDiaCalendarioRepository employeeRepository) {
        _repository = employeeRepository;
    }
    public async Task<TipoDiaCalendarioResponse> Handle(GetTipoDiaCalendarioByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.TipoDiaCalendario TipoDiaCalendario = await _repository.GetByIdAsync(request.Id);
        return MapperBase<TipoDiaCalendarioMappingProfile, TipoDiaCalendarioResponse>.MappEntity(TipoDiaCalendario);
    }
}



