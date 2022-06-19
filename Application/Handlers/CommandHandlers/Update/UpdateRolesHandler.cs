namespace Application.Handlers.CommandHandlers;

public class UpdateRolesHandler : IRequestHandler<UpdateRolesCommand, bool> {
    private readonly IRolesRepository _repostory;

    public UpdateRolesHandler(IRolesRepository RolesRepository) {
        _repostory = RolesRepository;
    }

    public async Task<bool> Handle(UpdateRolesCommand request, CancellationToken cancellationToken) {
        Core.Entities.Roles newEntity = MapperBase<RolesMappingProfile, Core.Entities.Roles>.MappEntity(request);
        Core.Entities.Roles oldEntity = await _repostory.GetByIdAsync(newEntity.Id);
        return await _repostory.ReplaceAsync(oldEntity,newEntity);
    }

}