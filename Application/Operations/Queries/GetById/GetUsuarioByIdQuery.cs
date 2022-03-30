
namespace Application.Operations.Queries;


public class GetUsuarioByIdQuery : IRequest<UsuarioResponse> {
    public int UsuarioID { get; set; }
}
   


