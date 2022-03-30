namespace Application.Handlers.CommandHandlers;
public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand,bool> {
    private IEmployeeRepository _context;
    public DeleteEmployeeHandler(IEmployeeRepository context) => this._context = context;
    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken) {
        Core.Entities.Employee employeeEntitiy = MapperBase<EmployeeMappingProfile, Core.Entities.Employee>.MappEntity(request);
        if (employeeEntitiy is null)  throw new ApplicationException("Issue with mapper");
        return await _context.DeleteAsync(employeeEntitiy);
    }
}

