
namespace Infrastructure.Repositories;
public class EmployeeRepository : IEmployeeRepository {

    EmployeeContext _context;
    RepositoryBase<Core.Entities.Employee,int,EmployeeContext> baseOperations;
    public  EmployeeRepository(EmployeeContext context) { 
        _context = context;
        baseOperations = new(_context);
    
    }

    public Task<Employee> AddAsync(Employee entity) {
        entity.EmployeeId = GenerateKey();



        return baseOperations.AddAsync(entity);
    }
    public int GenerateKey() {
        var context = _context.Employees;
        int max = context.Count();
        List<int> ExpectedKeys = Enumerable.Range(0, max).ToList();
        List<int> DBKeys = context.Select(i => i.EmployeeId).ToList();
        return ExpectedKeys.Except(DBKeys).First();
    }
    

    public Task<bool> DeleteAsync(Employee entity)
        => baseOperations.DeleteAsync(entity);

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

