using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace API.Controllers;

    [Route("api/[controller]")]
[ApiController]
public class ProyectoController : ControllerBase {
    private readonly IMediator _mediator;
    public ProyectoController(IMediator mediator) {
        _mediator = mediator;
    }


    [HttpGet("GetAllProyectos")]
    public async Task<IEnumerable<ProyectoResponse>> GetAll() {
        return await _mediator.Send(new GetAllProyectosQuery());

    }

    [HttpGet("GetProyectoById/{idProyecto}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ProyectoResponse> GetById(int idProyecto) {
        return await _mediator.Send(new GetProyectoByIdQuery() { IdProyecto = idProyecto });
    }

    [HttpPost("CreateProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> Create([FromBody] CreateProyectoCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }



    [HttpPut("UpdateProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> Update(UpdateProyectoCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("DeleteProyecto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> Delete(DeleteProyectoCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

