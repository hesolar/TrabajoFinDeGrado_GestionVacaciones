
namespace TipoDiaCalendario.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TipoDiaCalendarioController : ControllerBase {
    private readonly IMediator _mediator;
    public TipoDiaCalendarioController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllTipoDiaCalendario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<TipoDiaCalendarioResponse>> Get() {
        return await _mediator.Send(new GetAllTipoDiaCalendarioQuery());
    }
    [HttpPost("CreateTipoDiaCalendario")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<bool>> CreateTipoDiaCalendario([FromBody] CreateTipoDiaCalendarioCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result);
    }



    [HttpGet("GetTipoDiaCalendarioById/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<TipoDiaCalendarioResponse> GetById(int id) {
        return await _mediator.Send(new GetTipoDiaCalendarioByIdQuery() { Id = id });
    }
}
