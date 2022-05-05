namespace Api.Controllers.App;
[Route("api/[controller]")]
[ApiController]
public class TecnicoProyectosController : ControllerBase {
    private readonly IMediator _mediator;
    public TecnicoProyectosController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllTecnicoProyectos")]
    // GET: api/<TecnicoProyectosController>
    public async Task<IEnumerable<TecnicoProyectosResponse>> GetAll() {
        return await _mediator.Send(new GetAllTecnicoProyectosQuery());
    }

    [HttpGet("GetTecnicoProyectosById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TecnicoProyectosResponse> GetById(int id) {
        return await _mediator.Send(new GetTecnicoProyectosByIdQuery() { IdProyecto = id });
    }

    [HttpPost("CreateTecnicoProyectos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> Create([FromBody] CreateTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }



    [HttpPut("UpdateTecnicoProyectos")]
    public async Task<ActionResult<bool>> Update(UpdateTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // DELETE api/<RolesController>/5
    [HttpDelete("DeleteTecnicoProyectos")]
    public async Task<ActionResult<bool>> Delete([FromBody] DeleteTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
}

