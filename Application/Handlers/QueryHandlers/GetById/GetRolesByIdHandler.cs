namespace Application.Operations.Queries;

public class GetRolesByIdHandler : IRequestHandler<GetRolesByIdQuery, RolesResponse> {
    private readonly IRolesRepository _repository;
    public GetRolesByIdHandler(IRolesRepository employeeRepository) {
        _repository = employeeRepository;
    }
    public async Task<RolesResponse> Handle(GetRolesByIdQuery request, CancellationToken cancellationToken) {
        Core.Entities.Roles Roles = await _repository.GetByIdAsync(request.ID);
        return MapperBase<RolesMappingProfile, RolesResponse>.MappEntity(Roles);
    }
}



