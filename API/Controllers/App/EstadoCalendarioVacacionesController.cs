
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EstadoCalendarioVacacionesController : ControllerBase {
    private readonly IMediator _mediator;
    public EstadoCalendarioVacacionesController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllEstadoCalendarioVacaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<EstadoCalendarioVacacionesResponse>> GetAll() {
        return await _mediator.Send(new GetAllEstadoCalendarioVacacionesQuery());

    }


}


