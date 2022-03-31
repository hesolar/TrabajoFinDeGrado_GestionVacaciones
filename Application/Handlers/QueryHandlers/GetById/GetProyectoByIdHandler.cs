namespace Application.Operations.Queries;

public class GetProyectoByIdHandler : IRequestHandler<GetProyectoByIdQuery, ProyectoResponse> {
    private readonly IProyectoRepository _repository;
    public GetProyectoByIdHandler(IProyectoRepository employeeRepository) {
        _repository = employeeRepository;
    }
    public async Task<ProyectoResponse> Handle(GetProyectoByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.Proyecto Proyecto = await _repository.GetByIdAsync(request.IdProyecto);
        return MapperBase<ProyectoMappingProfile, ProyectoResponse>.MappEntity(Proyecto);
    }
}



