namespace Application.Handlers.QueryHandlers;

public class GetUsuarioByIdHandler : IRequestHandler<GetUsuarioByIdQuery, UsuarioResponse> {
    private readonly IUsuarioRepository _repository;

    public GetUsuarioByIdHandler(IUsuarioRepository repo) {
        _repository = repo;
    }
    public async Task<UsuarioResponse> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken) {

        //Core.Entities.Usuario employee = MapperBase<UsuarioMappingProfile, Core.Entities.Employee>.MappEntity(request);
        Core.Entities.Usuario employee = await _repository.GetByIdAsync(request.UsuarioID);
        return MapperBase<UsuarioMappingProfile, UsuarioResponse>.MappEntity(employee);
    }
}
