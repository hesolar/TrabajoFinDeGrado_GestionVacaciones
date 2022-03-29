

namespace Infrastructure.Data;

public class EmployeeContext : DbContext {
    public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) {

    }

    public DbSet<Core.Entities.Employee> Employees { get; set; }
}

