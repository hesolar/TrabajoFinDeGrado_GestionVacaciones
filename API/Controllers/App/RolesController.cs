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
    [HttpGet("{id}")]
    public string Get(int id) {
        return "value";
    }

    // POST api/<RolesController>
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/<RolesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/<RolesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }

}
