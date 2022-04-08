
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsuarioProyectoController : ControllerBase {
    private readonly IMediator _mediator;
    public UsuarioProyectoController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllUsuarioProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<UsuarioProyectoResponse>> Get() {
        return await _mediator.Send(new GetAllUsuarioProyectoQuery());
    }
    [HttpPost("CreateUsuarioProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> CreateUsu([FromBody] CreateUsuarioProyectoCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpDelete("DeleteUsuarioProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> DeleteUsuario(DeleteUsuarioProyectoCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }


   
    [HttpGet("GetProyectosUsuario/{idTecnico}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<int>> GetProyectos(int idTecnico) {
        return await _mediator.Send(new GetProyectos_De_UsuarioQuery() { idTecnico=idTecnico});
    }

    [HttpGet("GetUsuariosProyecto/{Proyecto}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<int>> GetUsuariosproyecto(int Proyecto) {
        return await _mediator.Send(new GetUsuarios_De_ProyectoQuery() { Proyecto = Proyecto });
    }
}

