namespace Application.Handlers.CommandHandlers;

public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, bool> {
    private readonly IEmployeeRepository _repostory;

    public UpdateEmployeeHandler(IEmployeeRepository employeeRepository) {
        _repostory = employeeRepository;
    }

    public async Task<bool> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken) {
        Core.Entities.Employee newEntity = MapperBase<EmployeeMappingProfile,Core.Entities.Employee>.MappEntity(request);
        Core.Entities.Employee oldEntity = await _repostory.GetByIdAsync(newEntity.EmployeeId);
        return await _repostory.UpdateAsync(oldEntity,newEntity);
    }


}


