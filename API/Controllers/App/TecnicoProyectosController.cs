namespace Api.Controllers.App;
[Route("api/[controller]")]
[ApiController]
public class TecnicoProyectosController : ControllerBase {
    private readonly IMediator _mediator;
    public TecnicoProyectosController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAll")]
    // GET: api/<TecnicoProyectosController>
    public async Task<IEnumerable<TecnicoProyectosResponse>> GetAll() {
        return await _mediator.Send(new GetAllTecnicoProyectosQuery());
    }

    [HttpGet("GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TecnicoProyectosResponse> GetById(int id) {
        return await _mediator.Send(new GetTecnicoProyectosByIdQuery() { IdProyecto = id });
    }

    [HttpPost("Create")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> Create([FromBody] CreateTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }



    [HttpPut("Update")]
    public async Task<ActionResult<String>> Update(UpdateTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    // DELETE api/<RolesController>/5
    [HttpDelete("Delete")]
    public async Task<ActionResult<String>> Delete([FromBody] DeleteTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }
}

