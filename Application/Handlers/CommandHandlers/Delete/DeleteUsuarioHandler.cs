namespace Application.Handlers.CommandHandlers;
public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, bool> {
   
    private IUsuarioRepository _context;
    public DeleteUsuarioHandler(IUsuarioRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken) 
       =>  await _context.DeleteAsync(request.IdTecnico);
    
}

