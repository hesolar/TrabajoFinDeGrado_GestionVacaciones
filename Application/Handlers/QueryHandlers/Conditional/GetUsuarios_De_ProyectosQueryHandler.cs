namespace Application.Handlers.QueryHandlers;


public class GetUsuarios_De_ProyectosQueryHandler : IRequestHandler<GetUsuarios_De_ProyectoQuery, IEnumerable<int>> {
    private readonly IUsuarioProyectoRepository _repository;

    public GetUsuarios_De_ProyectosQueryHandler(IUsuarioProyectoRepository repository) {
        _repository = repository;
    }

    

   async Task<IEnumerable<int>> IRequestHandler<GetUsuarios_De_ProyectoQuery, IEnumerable<int>>.Handle(GetUsuarios_De_ProyectoQuery request, CancellationToken cancellationToken) 
        => await _repository.GetUsuarioProyectos(request.Proyecto);
    
}
