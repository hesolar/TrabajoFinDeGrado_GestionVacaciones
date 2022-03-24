
namespace Core.Entities;

public class Employee {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Int32 EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

}

