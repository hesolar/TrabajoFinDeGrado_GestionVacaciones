
namespace Employee.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Core.Entities.Usuario>> Get()
        {
            return await _mediator.Send(new GetAllUsuariosQuery());
        }
        [HttpPost("CreateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UsuarioResponse>> CreateEmployee([FromBody] CreateUsuarioCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }





    }
}
