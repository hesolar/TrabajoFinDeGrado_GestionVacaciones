namespace Application.Handlers.CommandHandlers;
public class CreateUsuarioProyectoHandler : IRequestHandler<CreateUsuarioProyectoCommand, bool> {
    private readonly IUsuarioProyectoRepository _repo;

    public CreateUsuarioProyectoHandler(IUsuarioProyectoRepository repo) {
        _repo = repo;
    }
    public async Task<bool> Handle(CreateUsuarioProyectoCommand request, CancellationToken cancellationToken) {
        return await _repo.NuevoProyectoUsuario(request.IdTecnico, request.Proyecto);
    }


}
