
namespace Application.Operations.Queries;

public class GetRolesByIdQuery : IRequest<RolesResponse> {
    public int ID { get; set; }
}

