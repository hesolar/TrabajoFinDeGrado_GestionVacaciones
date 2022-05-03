
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase {
    private readonly IMediator _mediator;
    public UsuarioController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllUsuarios")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<UsuarioResponse>> Get() {
        return await _mediator.Send(new GetAllUsuariosQuery());
    }
    [HttpPost("CreateUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> CreateUsuario([FromBody] CreateUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("DeleteUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> DeleteUsuario(DeleteUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpPut("UpdateUsuario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> UpdateUsuario(UpdateUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    [HttpGet("GetUsuarioById/{idUsuario}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<UsuarioResponse> GetById(int idUsuario) {
        return await _mediator.Send(new GetUsuarioByIdQuery() { UsuarioID = idUsuario });
    }
    [HttpGet("GetUsuarioByCorreoEmpresa/{correoEmpresa}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<UsuarioResponse> GetByCorreoEmpresa(String correoEmpresa ) {
        var xd= await _mediator.Send(new GetUsuarioByCorreoEmpresaQuery() { CorreoEmpresa = correoEmpresa });
        return xd;
    }

}

