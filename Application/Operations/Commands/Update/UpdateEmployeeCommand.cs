namespace Application.Operations.Commands;

public class UpdateEmployeeCommand: IRequest<bool> {
    public Int32 EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
