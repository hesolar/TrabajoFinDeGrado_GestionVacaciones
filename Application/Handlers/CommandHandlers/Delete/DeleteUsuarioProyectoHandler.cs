namespace Application.Handlers.CommandHandlers;
public class DeleteUsuarioProyectoHandler : IRequestHandler<DeleteUsuarioProyectoCommand, bool> {

    private IUsuarioProyectoRepository _context;

    public DeleteUsuarioProyectoHandler(IUsuarioProyectoRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteUsuarioProyectoCommand request, CancellationToken cancellationToken) 
    
     => await _context.DeleteByIdAsync(Tuple.Create(request.IdTecnico,request.IdProyecto));
    
    
    
}

