namespace Application.Handlers.QueryHandlers;

public class GetAllUsuariosHandler: IRequestHandler<GetAllUsuariosQuery, List<Core.Entities.Usuario>> {
    private readonly IUsuarioRepository _repo;

    public GetAllUsuariosHandler(IUsuarioRepository repo) {
        _repo = repo;
    }
    public async Task<List<Core.Entities.Usuario>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken) {
       
        var f = await _repo.GetAllAsync();

        return (List<Core.Entities.Usuario>)await _repo.GetAllAsync();
    }
}
