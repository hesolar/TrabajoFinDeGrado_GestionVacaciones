namespace Application.Handlers.CommandHandlers;

public class DeleteRolesHandler : IRequestHandler<DeleteRolesCommand, bool> {

    private IRolesRepository _context;
    public DeleteRolesHandler(IRolesRepository context) 
        => this._context = context;

    public async Task<bool> Handle(DeleteRolesCommand request, CancellationToken cancellationToken)
       => await _context.DeleteAsync(request.Id);

}