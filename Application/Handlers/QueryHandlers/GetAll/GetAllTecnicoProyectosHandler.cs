namespace Application.Handlers.QueryHandlers;

public class GetAllTecnicoProyectosHandler : IRequestHandler<GetAllTecnicoProyectosQuery, IEnumerable<TecnicoProyectosResponse>> {
    private readonly ITecnicoProyectosRepository _repo;

    public GetAllTecnicoProyectosHandler(ITecnicoProyectosRepository repo) {
        _repo = repo;
    }
    public async Task<IEnumerable<TecnicoProyectosResponse>> Handle(GetAllTecnicoProyectosQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.TecnicoProyectos> proyectos = await _repo.GetAllAsync();
        return MapperBase<TecnicoProyectosMappingProfile, TecnicoProyectosResponse>.MappIEnumerable(proyectos);
    }
}
