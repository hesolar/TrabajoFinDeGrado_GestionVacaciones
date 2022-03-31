namespace Api.Controllers.App;

    [Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase {
    private readonly IMediator _mediator;
    public RolesController(IMediator mediator) {
        _mediator = mediator;
    }

    // GET: api/<RolesController>
    [HttpGet("GetAll")]
    public async Task< IEnumerable<RolesResponse>> Get() {
        return await _mediator.Send(new GetAllRolesQuery());

    }

    // GET api/<RolesController>/5
    [HttpGet("GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<RolesResponse> GetById(int id) {
        return await _mediator.Send(new GetRolesByIdQuery() {  ID = id });
    }

    // POST api/<RolesController>
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    [HttpPut("Update")]
    public async Task<ActionResult<String>> Update(UpdateRolesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    // DELETE api/<RolesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }

}
