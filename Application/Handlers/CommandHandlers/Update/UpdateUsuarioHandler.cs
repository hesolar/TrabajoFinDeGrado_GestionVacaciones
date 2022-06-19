namespace Application.Handlers.CommandHandlers;

public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioCommand, bool> {
    private readonly IUsuarioRepository _repostory;

    public UpdateUsuarioHandler(IUsuarioRepository usuarioRepository) {
        _repostory = usuarioRepository;
    }

    public async Task<bool> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken) {
        Core.Entities.Usuario newEntity = MapperBase<UsuarioMappingProfile,Core.Entities.Usuario>.MappEntity(request);
        Core.Entities.Usuario oldEntity = await _repostory.GetByIdAsync(newEntity.IdTecnico);
        
        return await _repostory.ReplaceAsync(oldEntity,newEntity);
    }


}