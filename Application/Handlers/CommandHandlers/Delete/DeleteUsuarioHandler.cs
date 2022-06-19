namespace Application.Handlers.CommandHandlers;
public class DeleteUsuario : IRequestHandler<DeleteUsuarioCommand, bool> {

    private IUsuarioRepository _context;

    public DeleteUsuario(IUsuarioRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken) 
       =>  await _context.DeleteByIdAsync(request.IdTecnico);
    
}

