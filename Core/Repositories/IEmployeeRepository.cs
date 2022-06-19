namespace Core.Repositories;

public interface IEmployeeRepository : IRepositoryBase<Employee,int> {
    //custom operations here
    Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname);
}

