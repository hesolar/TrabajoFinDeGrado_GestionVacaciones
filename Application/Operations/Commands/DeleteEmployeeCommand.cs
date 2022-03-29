namespace Application.Operations.Commands;
public class DeleteEmployeeCommand : IRequest<bool> {
   public int EmployeeID { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
}
