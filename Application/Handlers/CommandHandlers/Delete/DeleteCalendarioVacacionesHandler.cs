namespace Application.Handlers.CommandHandlers;

public class DeleteCalendarioVacacionesHandler : IRequestHandler<DeleteCalendarioVacacionesCommand, bool> {
    private ICalendarioVacacionesRepository _context;
    public DeleteCalendarioVacacionesHandler(ICalendarioVacacionesRepository context) => this._context = context;
    public async Task<bool> Handle(DeleteCalendarioVacacionesCommand request, CancellationToken cancellationToken) {
        Tuple<int, DateTime> key = Tuple.Create(request.UsuarioID, request.Fecha);
        return await _context.DeleteAsync(key);
    }
}

