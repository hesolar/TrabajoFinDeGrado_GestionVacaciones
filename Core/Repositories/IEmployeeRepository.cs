namespace Core.Repositories;

public interface IEmployeeRepository : IRepository<Employee,int> {
    //custom operations here
    Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname);
}

