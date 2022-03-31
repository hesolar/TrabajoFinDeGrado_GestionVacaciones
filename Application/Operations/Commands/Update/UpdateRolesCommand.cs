namespace Application.Operations.Commands;

public class UpdateRolesCommand : IRequest<bool> {
  public int Id { get; set; }
    public string Rol { get; set; }
}
