namespace Application.Handlers.QueryHandlers;


public class GetSubordinadosQueryHandler : IRequestHandler<GetSubordinadosQuery, IEnumerable<CalendarioVacacionesResponse>> {
    private readonly IUsuarioRepository _repository;

    public GetSubordinadosQueryHandler(IUsuarioRepository calendarioVacacionesRepository) {
        _repository = calendarioVacacionesRepository;
    }

     Task<IEnumerable<CalendarioVacacionesResponse>> IRequestHandler<GetSubordinadosQuery, IEnumerable<CalendarioVacacionesResponse>>.Handle(GetSubordinadosQuery request, CancellationToken cancellationToken) {
        throw new NotImplementedException();
        _repository.GetSubordinados(request.Proyectos, request.WebRol);
    }
}

