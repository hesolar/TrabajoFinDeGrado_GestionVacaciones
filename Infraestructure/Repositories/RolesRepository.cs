namespace Infrastructure.Repositories;
public class RolesRepository : IRolesRepository {

    RolesContext _context;
    RepositoryBase<Core.Entities.Roles, int, RolesContext> baseOperations;
    public RolesRepository(RolesContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public Task<bool> AddAsync(Roles entity) 
        => baseOperations.AddAsync(entity);
    

    public Task<IReadOnlyList<Roles>> GetAllAsync() 
        => baseOperations.GetAllAsync();


    public Task<Roles> GetByIdAsync(int id) 
        => baseOperations.GetByIdAsync(id);

    public async Task<bool> DeleteAsync(Roles entity)
        => await baseOperations.DeleteAsync(entity);

    public Task<bool> UpdateAsync(Roles entity)
      => baseOperations.UpdateAsync(_context.Roles.First(x => entity.Id == x.Id), entity);
}

