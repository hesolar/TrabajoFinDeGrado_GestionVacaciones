namespace Application.Operations.Commands;

public class CreateRolesCommand : IRequest<bool> {
    public int Id { get; set; }
    public string Rol { get; set; }

}
