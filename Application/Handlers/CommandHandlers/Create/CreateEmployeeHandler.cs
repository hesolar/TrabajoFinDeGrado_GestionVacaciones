namespace Application.Handlers.CommandHandlers;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, bool> {
    private readonly IEmployeeRepository _employeeRepo;

    public CreateEmployeeHandler(IEmployeeRepository employeeRepository) {
        _employeeRepo = employeeRepository;
    }
    public async Task<bool> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken) {
        Core.Entities.Employee employeeEntitiy = MapperBase<EmployeeMappingProfile, Core.Entities.Employee>.MappEntity(request);
        if (employeeEntitiy is null) throw new ApplicationException("Issue with mapper");
        return await _employeeRepo.AddAsync(employeeEntitiy);
    }
}
