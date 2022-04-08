namespace Application.Handlers.QueryHandlers;


public class GetProyectos_De_UsuarioQueryHandler : IRequestHandler<GetProyectos_De_UsuarioQuery, IEnumerable<int>> {
    private readonly IUsuarioProyectoRepository _repository;

    public GetProyectos_De_UsuarioQueryHandler(IUsuarioProyectoRepository repository) {
        _repository = repository;
    }

    public Task<IEnumerable<int>> Handle(GetProyectos_De_UsuarioQuery request, CancellationToken cancellationToken) {
        return _repository.GetProyectosUsuario(request.idTecnico);
    }

   
}

