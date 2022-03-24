namespace Core.Repositories;

public interface IEmployeeRepository : IRepository<Core.Entities.Employee> {
    //custom operations here
    Task<IEnumerable<Core.Entities.Employee>> GetEmployeeByLastName(string lastname);
}

