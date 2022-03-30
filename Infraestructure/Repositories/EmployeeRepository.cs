
namespace Infrastructure.Repositories;
public class EmployeeRepository : IEmployeeRepository {

    EmployeeContext _context;
    RepositoryBase<Core.Entities.Employee,int,EmployeeContext> baseOperations;
    public  EmployeeRepository(EmployeeContext context) { 
        _context = context;
        baseOperations = new(_context);
    
    }

    public Task<bool> AddAsync(Employee entity) 
        => baseOperations.AddAsync(entity);
    

    

    public Task<bool> DeleteAsync(int entity)
        => baseOperations.DeleteAsync(_context.Employees.First(x=>x.EmployeeId==entity));

    public Task<IReadOnlyList<Employee>> GetAllAsync() => baseOperations.GetAllAsync();

    public Task<Employee> GetByIdAsync(int id) =>baseOperations.GetByIdAsync(id);

    public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname) {
        
        return await _context.Employees.Where(m => m.LastName == lastname).ToListAsync();
    }

    public Task<bool> UpdateAsync(Employee entity) {
        var oldEntity= _context.Employees.First(X=> X.EmployeeId == entity.EmployeeId);
       return  baseOperations.UpdateAsync(oldEntity, entity);
    }
    

   
    
}

