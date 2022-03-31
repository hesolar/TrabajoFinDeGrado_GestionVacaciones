namespace Application.Handlers.CommandHandlers;

public class UpdateRolesHandler : IRequestHandler<UpdateRolesCommand, bool> {
    private readonly IRolesRepository _repostory;

    public UpdateRolesHandler(IRolesRepository RolesRepository) {
        _repostory = RolesRepository;
    }

    public async Task<bool> Handle(UpdateRolesCommand request, CancellationToken cancellationToken) {
        Core.Entities.Roles entity = MapperBase<RolesMappingProfile, Core.Entities.Roles>.MappEntity(request);
        return await _repostory.UpdateAsync(entity);
    }

}