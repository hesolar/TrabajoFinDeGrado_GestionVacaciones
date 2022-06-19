
namespace Infrastructure.Repositories;
public class EmployeeRepository : RepositoryBase<Employee, int>, IEmployeeRepository {
    

    public  EmployeeRepository(Context context) : base(context){ 

    }

    public override async Task<bool> DeleteByIdAsync(int entity)
        =>await base.DeleteAsync(_context.Employees.First(x=>x.EmployeeId==entity));



    public async Task<IEnumerable<Employee>> GetEmployeeByLastName(string lastname) {
        
        return await _context.Employees.Where(m => m.LastName == lastname).ToListAsync();
    }

    public Task<bool> UpdateAsync(Employee entity) {
       var oldEntity= _context.Employees.First(X=> X.EmployeeId == entity.EmployeeId);
       return  base.UpdateAsync(oldEntity, entity);
    }
    

   
    
}

