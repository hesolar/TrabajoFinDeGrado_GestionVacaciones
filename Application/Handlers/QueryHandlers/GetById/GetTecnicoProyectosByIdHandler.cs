namespace Application.Operations.Queries;

public class GetTecnicoProyectosByIdHandler : IRequestHandler<GetTecnicoProyectosByIdQuery, TecnicoProyectosResponse> {
    private readonly ITecnicoProyectosRepository _repository;
    public GetTecnicoProyectosByIdHandler(ITecnicoProyectosRepository employeeRepository) {
        _repository = employeeRepository;
    }
    public async Task<TecnicoProyectosResponse> Handle(GetTecnicoProyectosByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.TecnicoProyectos TecnicoProyectos = await _repository.GetByIdAsync(request.IdProyecto);
        return MapperBase<TecnicoProyectosMappingProfile, TecnicoProyectosResponse>.MappEntity(TecnicoProyectos);
    }
}



