namespace Application.Handlers.QueryHandlers;

public class GetAllProyectosHandler : IRequestHandler<GetAllProyectosQuery, IEnumerable<ProyectoResponse>> {
    private readonly IProyectoRepository _repo;

    public GetAllProyectosHandler(IProyectoRepository repo) {
        _repo = repo;
    }
    public async Task<IEnumerable<ProyectoResponse>> Handle(GetAllProyectosQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.Proyecto> Proyectos = await _repo.GetAllAsync();
        return MapperBase<ProyectoMappingProfile, ProyectoResponse>.MappIEnumerable(Proyectos);
    }
}
