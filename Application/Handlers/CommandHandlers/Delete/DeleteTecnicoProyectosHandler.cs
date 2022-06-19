namespace Application.Handlers.CommandHandlers;

public class DeleteTecnicoProyectosHandler : IRequestHandler<DeleteTecnicoProyectosCommand, bool> {

    private ITecnicoProyectosRepository _context;
    public DeleteTecnicoProyectosHandler(ITecnicoProyectosRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteTecnicoProyectosCommand request, CancellationToken cancellationToken)
       => await _context.DeleteByIdAsync(request.TecnicoProyectoId);

}