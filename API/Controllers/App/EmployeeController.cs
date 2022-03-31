
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase {
    private readonly IMediator _mediator;
    public EmployeeController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllEmployee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<EmployeeResponse>> Get() {
        return await _mediator.Send(new GetAllEmployeeQuery());
    }
    [HttpPost("CreateEmployee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> CreateEmployee([FromBody] CreateEmployeeCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpDelete("DeleteEmployee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> DeleteEmployee(DeleteEmployeeCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }
    [HttpPut("ReplaceEmployee")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> UpdateEmployee(UpdateEmployeeCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpGet("GetById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<EmployeeResponse> GetById(int id) {
        return await _mediator.Send(new GetEmployeeByIdQuery() { Id = id });
    }
}
