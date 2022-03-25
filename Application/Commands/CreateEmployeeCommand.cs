namespace Application.Commands;

public class CreateEmployeeCommand : IRequest<EmployeeResponse> 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
