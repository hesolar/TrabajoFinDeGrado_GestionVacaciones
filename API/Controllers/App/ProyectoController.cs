using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace Employee.API.Controllers;

    [Route("api/[controller]")]
[ApiController]
public class ProyectoController : ControllerBase {
    private readonly IMediator _mediator;
    public ProyectoController(IMediator mediator) {
        _mediator = mediator;
    }


    // GET: api/<ValuesController>
    [HttpGet("GetAllProyectos")]
    public async Task<IEnumerable<ProyectoResponse>> GetAll() {
        return await _mediator.Send(new GetAllProyectosQuery());

    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public string Get(int id) {
        return "value";
    }

    // POST api/<ValuesController>
    [HttpPost]
    public void Post([FromBody] string value) {
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value) {
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id) {
    }
}

