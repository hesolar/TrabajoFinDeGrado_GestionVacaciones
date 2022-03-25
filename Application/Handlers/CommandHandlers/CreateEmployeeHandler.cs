
namespace Application.Handlers.CommandHandlers;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, EmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepo;

    public CreateEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepo = employeeRepository;
    }
    public async Task<EmployeeResponse> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        Core.Entities.Employee employeeEntitiy = EmployeeMapper.Mapper.Map<Core.Entities.Employee>(request);
        if(employeeEntitiy is null)
        {
            throw new ApplicationException("Issue with mapper");
        }
        var newEmployee = await _employeeRepo.AddAsync(employeeEntitiy);
        var employeeResponse = EmployeeMapper.Mapper.Map<EmployeeResponse>(newEmployee);
        return employeeResponse;
    }
}
