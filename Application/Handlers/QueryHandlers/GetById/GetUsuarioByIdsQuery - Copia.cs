namespace Application.Handlers.QueryHandlers;

public class GetUsuarioByCorreoEmpresaQueryHandler : IRequestHandler<GetUsuarioByCorreoEmpresaQuery, UsuarioResponse> {
    private readonly IUsuarioRepository _repository;

    public GetUsuarioByCorreoEmpresaQueryHandler(IUsuarioRepository repo) {
        _repository = repo;
    }
    public async Task<UsuarioResponse> Handle(GetUsuarioByCorreoEmpresaQuery request, CancellationToken cancellationToken) {

        Core.Entities.Usuario usuario = await _repository.GetUsuarioByCorreo(request.CorreoEmpresa);
        return MapperBase<UsuarioMappingProfile, UsuarioResponse>.MappEntity(usuario);
    }
}
