using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI;

namespace WebApplication1.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger) {
        //    //_logger = logger;
        //}

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetHelloWorld")]
        public IList<String> HelloWorld() =>
            new List<String> { "Hello World!" };

        [HttpGet("GetHelloWorldFromDB")]
        public IEnumerable<String> HelloWorldFromDB() {
            //var serverName = @"HL-013920\SQLEXPRESS";
            //var database = "DockerService";
            //var queryString = "Select * from Saludos";
            //var connectionString = @$"Server={serverName}; Database={database}; Trusted_Connection=True;";
            //var connectionString = @"Data Source=HL-013920;Initial Catalog=DockerService; Database = {database};Integrated Security=true";
            //var str = @"Data Source =HL-013920\SQLEXPRESS; Initial Catalog = DockerService; Integrated Security = True; MultipleActiveResultSets = True";
            //var cadena2 = $"Server = {serverName}; Database = {database}; Trusted_Connection = True";
            var CadenaBuena = "Data Source=HL-013920;Initial Catalog=DockerService;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            using (SqlConnection connection = new (CadenaBuena)) {
                SqlCommand command = new ("Select * from Saludos", connection);
                command.Connection.Open();
                var resultado = command.ExecuteReader();
            }

            return new List<String>();
        }

        [HttpGet("GetUserHolidays")]
        public IEnumerable<String> GetHolidaysUser() {

            return new List<String>();
        }



    }
}