
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase {
    private readonly IMediator _mediator;
    public UsuarioController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<UsuarioResponse>> Get() {
        return await _mediator.Send(new GetAllUsuariosQuery());
    }
    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> CreateUsuario([FromBody] CreateUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpDelete("Delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> DeleteUsuario(DeleteUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }
    [HttpPut("Update")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> UpdateUsuario(UpdateUsuarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }
    [HttpGet("GetById/{idUsuario}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<UsuarioResponse> GetById(int idUsuario) {
        return await _mediator.Send(new GetUsuarioByIdQuery() { UsuarioID = idUsuario });
    }


}

