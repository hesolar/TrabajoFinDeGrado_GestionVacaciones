namespace Application.Handlers.QueryHandlers;

public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, IEnumerable<UsuarioResponse>> {
    private readonly IUsuarioRepository _repo;

    public GetAllUsuariosHandler(IUsuarioRepository repo) {
        _repo = repo;
    }
    public async Task<IEnumerable<UsuarioResponse>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.Usuario> usuarios = await _repo.GetAllAsync(); 
        return MapperBase<UsuarioMappingProfile, UsuarioResponse>.MappIEnumerable(usuarios);
    }
}
