namespace Application.Handlers.CommandHandlers;

public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, bool> {
    private readonly IUsuarioRepository _repostory;

    public UpdateUsuarioHandler(IUsuarioRepository usuarioRepository) {
        _repostory = usuarioRepository;
    }

    public async Task<bool> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken) {
        Core.Entities.Usuario entity = MapperBase<EmployeeMappingProfile,Core.Entities.Usuario>.MappEntity(request);
        return await _repostory.UpdateAsync(entity);
    }


}