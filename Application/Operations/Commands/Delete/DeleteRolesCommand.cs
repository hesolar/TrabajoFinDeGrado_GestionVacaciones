namespace Application.Operations.Commands;

public class DeleteRolesCommand: IRequest<bool> {
    public int Id { get; set; }

}
