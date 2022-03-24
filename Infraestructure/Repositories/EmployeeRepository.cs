

namespace Infrastructure.Repositories;

public class EmployeeRepository : Repository<Core.Entities.Employee>, IEmployeeRepository {
    public EmployeeRepository(EmployeeContext employeeContext) : base(employeeContext) {

    }
    public async Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname) {
        return await _employeeContext.Employees
            .Where(m => m.LastName == lastname)
            .ToListAsync();
    }
}

