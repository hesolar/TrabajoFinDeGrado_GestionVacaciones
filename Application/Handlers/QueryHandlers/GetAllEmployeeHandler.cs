namespace Application.Handlers.QueryHandlers;

public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeResponse>>
{
    private readonly IEmployeeRepository _repository;

    public GetAllEmployeeHandler(IEmployeeRepository employeeRepository){
        _repository = employeeRepository;
    }
    public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken){
        IReadOnlyList<Core.Entities.Employee> employees = await _repository.GetAllAsync();
        return  MapperBase<EmployeeMappingProfile, EmployeeResponse>.MappIEnumerable(employees);
    }
}
