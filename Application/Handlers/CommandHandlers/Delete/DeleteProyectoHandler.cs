namespace Application.Handlers.CommandHandlers;

public class DeleteProyectoHandler : IRequestHandler<DeleteProyectoCommand,bool> {
    private IProyectoRepository _context;

    public DeleteProyectoHandler(IProyectoRepository context) => _context = context;

    public async Task<bool> Handle(DeleteProyectoCommand request, CancellationToken cancellationToken) 
        =>await _context.DeleteAsync(request.IdProyecto);
    
}
