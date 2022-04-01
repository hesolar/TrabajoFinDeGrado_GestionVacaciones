namespace Api.Controllers.App;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase {
    private readonly IMediator _mediator;
    public RolesController(IMediator mediator) {
        _mediator = mediator;
    }

    // GET: api/<RolesController>
    [HttpGet("GetAllRoles")]
    public async Task< IEnumerable<RolesResponse>> Get() {
        return await _mediator.Send(new GetAllRolesQuery());

    }

    // GET api/<RolesController>/5
    [HttpGet("GetRolesById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]

    public async Task<RolesResponse> GetById(int id) {
        return await _mediator.Send(new GetRolesByIdQuery() {  ID = id });
    }

    [HttpPost("CreateRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> Create([FromBody] CreateRolesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }


    [HttpPut("UpdateRoles")]
    public async Task<ActionResult<String>> Update(UpdateRolesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    // DELETE api/<RolesController>/5
    [HttpDelete("DeleteRoles")]
    public async Task<ActionResult<String>> Delete([FromBody] DeleteRolesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

}
