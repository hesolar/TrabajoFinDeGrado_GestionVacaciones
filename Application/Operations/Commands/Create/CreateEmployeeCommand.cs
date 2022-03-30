namespace Application.Operations.Commands;

public class CreateEmployeeCommand : IRequest<bool> 
{
    public string FirstName { get; set; }
    public string LastName { get; set; }

}
