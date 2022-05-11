namespace Application.Handlers.QueryHandlers;

public class GetAllUsuarioProyectoHandler : IRequestHandler<GetAllUsuarioProyectoQuery, IEnumerable<UsuarioProyectoResponse>> {
    private readonly IUsuarioProyectoRepository _repo;

    public GetAllUsuarioProyectoHandler(IUsuarioProyectoRepository repo) {
        _repo = repo;
    }
    public async Task<IEnumerable<UsuarioProyectoResponse>> Handle(GetAllUsuarioProyectoQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.UsuarioProyecto> usuarios = await _repo.GetAllAsync(); 
        var xd = MapperBase<UsuarioProyectoMappingProfile, UsuarioProyectoResponse>.MappIEnumerable(usuarios); 

        return MapperBase<UsuarioProyectoMappingProfile, UsuarioProyectoResponse>.MappIEnumerable(usuarios);
    }
}
