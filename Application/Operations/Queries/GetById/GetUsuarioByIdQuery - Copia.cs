
namespace Application.Operations.Queries;


public class GetUsuarioByCorreoEmpresaQuery : IRequest<UsuarioResponse> {
    public string CorreoEmpresa { get; set; }
}
   


