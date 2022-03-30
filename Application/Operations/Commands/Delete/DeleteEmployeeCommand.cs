namespace Application.Operations.Commands;
public class DeleteEmployeeCommand : IRequest<bool> {
   public int EmployeeID { get; set; }

}
