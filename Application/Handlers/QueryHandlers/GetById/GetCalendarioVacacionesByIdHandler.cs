//namespace Application.Operations.Queries;

//public class GetCalendarioVacacionesByIdHandler : IRequestHandler<GetCalendarioVacacionesByIdQuery,CalendarioVacacionesResponse> {
//    private readonly ICalendarioVacacionesRepository _repository;
//    public GetCalendarioVacacionesByIdHandler(IEmployeeRepository employeeRepository) {
//        _repository = employeeRepository;
//    }
//    public async Task<IEnumerable<EmployeeResponse>> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken) {
//        Core.Entities.Employee employee = MapperBase<EmployeeMappingProfile, Core.Entities.Employee >.MappEntity(request);
//        employee= await _repository.GetByIdAsync(employee.EmployeeId);
//        return MapperBase<EmployeeMappingProfile, EmployeeResponse>.MappEntity(employee);
//    }
//}



//    public async Task<IEnumerable<EmployeeResponse>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken) {
//        IReadOnlyList<Core.Entities.Employee> employees = await _repository.GetAllAsync();
//        return MapperBase<EmployeeMappingProfile, EmployeeResponse>.MappIEnumerable(employees);
//    }
//}