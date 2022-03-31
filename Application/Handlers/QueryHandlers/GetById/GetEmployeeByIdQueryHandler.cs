
namespace Application.Handlers.QueryHandlers;

public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeResponse> {
    private readonly IEmployeeRepository _repository;

    public GetEmployeeByIdQueryHandler(IEmployeeRepository repo) {
        _repository = repo;
    }
    public async Task<EmployeeResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.Employee employee = await _repository.GetByIdAsync(request.Id);
        return MapperBase<EmployeeMappingProfile, EmployeeResponse>.MappEntity(employee);
    }
}
