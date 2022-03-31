namespace Application.Handlers.CommandHandlers;

public class CreateRolesHandler : IRequestHandler<CreateRolesCommand, bool> {
    private readonly IRolesRepository _rolesRepo;
    public CreateRolesHandler(IRolesRepository employeeRepository) {
        _rolesRepo = employeeRepository;
    }
    public async Task<bool> Handle(CreateRolesCommand request, CancellationToken cancellationToken) {
        var employeeEntitiy = MapperBase<RolesMappingProfile, Core.Entities.Roles>.MappEntity(request);
        if (employeeEntitiy is null) throw new ApplicationException("Issue with mapper");
        return await _rolesRepo.AddAsync(employeeEntitiy);
    }
}
