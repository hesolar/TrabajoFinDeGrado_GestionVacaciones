namespace Infrastructure.Repositories;
public class RolesRepository : RepositoryBase<Core.Entities.Roles, int>, IRolesRepository {
    
    public RolesRepository(Context context):base(context) {

    }

    public override async Task<bool> DeleteByIdAsync(int entity)
        => await base.DeleteAsync(_context.Roles.First(x=>x.Id==entity));

    public override async Task<bool> UpdateAsync(Roles oldEntity, Roles newEntity)
      => await base.UpdateAsync(oldEntity,newEntity);
    public override async Task<bool> DeleteAsync(Roles entity)
    => await base.DeleteAsync(entity);

}

