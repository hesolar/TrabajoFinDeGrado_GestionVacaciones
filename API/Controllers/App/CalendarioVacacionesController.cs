
namespace Employee.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CalendarioVacacionesController : ControllerBase {
    private readonly IMediator _mediator;
    public CalendarioVacacionesController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpGet("GetAllCalendarioVacaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<CalendarioVacacionesResponse>> GetAll() {
        return await _mediator.Send(new GetAllCalendarioVacacionesQuery());

    }

    [HttpPost("CreateCalendarioVacaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<CalendarioVacacionesResponse>> Create([FromBody] CreateCalendarioVacacionesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpDelete("DeleteCalendarioVacaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> Delete(DeleteCalendarioVacacionesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpPut("UpdateCalendarioVacaciones")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<String>> Update(UpdateCalendarioVacacionesCommand command) {
        var result = await _mediator.Send(command);
        return Ok(result.Completion());
    }

    [HttpGet("GetCalendarioVacacionesById/{idTecnico}/{Fecha}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<CalendarioVacacionesResponse> GetById(int idTecnico, DateTime Fecha) {
        return await _mediator.Send(new GetCalendarioVacacionesByIdQuery() { IdTecnico = idTecnico, Fecha = Fecha });

    }


    [HttpGet("GetUsuarioCalendarioVacaciones/{idTecnico}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<CalendarioVacacionesResponse>> GetCalendarioVacaciones(int idTecnico) {
        return await _mediator.Send(new GetCalendarioVacacionesUsuarioQuery() { Id = idTecnico } );

    }

    [HttpPut("AddCalendarioVacacionesNoSaved")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<CalendarioVacacionesResponse>> addNuevosCalendariosVacaciones(IEnumerable<CalendarioVacacionesResponse> nuevos ) {
        return await _mediator.Send(new AddNonSavedCalendarioVacacionesCommand() { nuevosDias= nuevos });

    }


    [HttpGet("CalendarioVacaciones/{Proyecto}/{WebRol}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IEnumerable<CalendarioVacacionesResponse>> GetCalendarioVacacionesSubordinados(IEnumerable<int> Proyectos, int WebRol) {
        return  await _mediator.Send(new GetSubordinadosQuery() { Proyectos=Proyectos, WebRol=WebRol});


    }



}


