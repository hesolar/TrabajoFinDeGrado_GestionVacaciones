namespace Application.Handlers.CommandHandlers;
public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, bool> {
   
    private IUsuarioRepository _context;
    public DeleteUsuarioHandler(IUsuarioRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken) {
        Core.Entities.Usuario usuarioEntity = MapperBase<UsuarioMappingProfile,Core.Entities.Usuario>.MappEntity(request);
        if (usuarioEntity is null)throw new ApplicationException("Issue with mapper");
        return await _context.DeleteAsync(usuarioEntity);
    }
}

