

using Core.Entities;

namespace Infrastructure.Repositories;

public class EmployeeRepository : IRepository<Core.Entities.Employee>, IEmployeeRepository {
    //public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext) {

    //}
    //public async Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname) {
    //    return await base._context.Employees
    //        .Where(m => m.LastName == lastname)
    //        .ToListAsync();
    //}
    EmployeeContext _context;
    RepositoryBase<Core.Entities.Employee,EmployeeContext> baseOperations;
    public  EmployeeRepository(EmployeeContext context) { 
        _context = context;
        baseOperations = new(_context);
    
    }

    public Task<Employee> AddAsync(Employee entity) =>baseOperations.AddAsync(entity);

    public Task DeleteAsync(Employee entity)=> baseOperations.DeleteAsync(entity);

    public Task<IReadOnlyList<Employee>> GetAllAsync() => baseOperations.GetAllAsync();

    public Task<Employee> GetByIdAsync(int id) =>baseOperations.GetByIdAsync(id);

    public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname) {
        
        return await _context.Employees.Where(m => m.LastName == lastname).ToListAsync();
    }

    public virtual Task UpdateAsync(Employee entity) {
        throw new NotImplementedException();
    }
}

