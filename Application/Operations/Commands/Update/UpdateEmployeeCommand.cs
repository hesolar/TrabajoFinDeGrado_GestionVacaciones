namespace Application.Operations.Commands;

public class UpdateEmployeeCommand: IRequest<bool> {
    public int IdTecnico  { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
