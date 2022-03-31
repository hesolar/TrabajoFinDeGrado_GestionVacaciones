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

    // POST api/<TecnicoProyectosController>
    [HttpPost]
    public void Post([FromBody] string value) {
    }


    [HttpPut("Update")]
    public async Task<ActionResult<String>> Update(UpdateTecnicoProyectosCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    // DELETE api/<TecnicoProyectosController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
}

