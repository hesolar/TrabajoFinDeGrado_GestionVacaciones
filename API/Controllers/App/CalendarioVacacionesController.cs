
namespace Employee.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarioVacacionesController : ControllerBase {
        private readonly IMediator _mediator;
        public CalendarioVacacionesController(IMediator mediator) {
            _mediator = mediator;
        }

        [HttpGet("GetAllCalendarioVacaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<CalendarioVacacionesResponse>> Get() {
            return await _mediator.Send(new GetAllCalendarioVacacionesQuery());
          
        }

        [HttpPost("CreateCalendarioVacaciones")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CalendarioVacacionesResponse>> CreateEmployee([FromBody] CreateCalendarioVacacionesCommand command) {
            var result = await _mediator.Send(command);
            return Ok(result.Completion());
        }

        //[HttpDelete("DeleteCalendarioVacaciones")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<String>> DeleteEmployee(DeleteCalendarioVacaciones command) {
        //    var result = await _mediator.Send(command);
        //    return Ok(result.Completion());
        //}

        //[HttpPut("ReplaceEmployee")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<String>> UpdateEmployee(UpdateCalendarioVacacionesCommand command) {
        //    var result = await _mediator.Send(command);
        //    return Ok(result.Completion());
        //}



    }
}

