namespace Application.Handlers.QueryHandlers;

public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, List<Core.Entities.Employee>>
{
    private readonly IEmployeeRepository _employeeRepo;

    public GetAllEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepo = employeeRepository;
    }
    public async Task<List<Core.Entities.Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        return (List<Core.Entities.Employee>)await _employeeRepo.GetAllAsync();
    }
}
