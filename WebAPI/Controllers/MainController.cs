using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using WebAPI.Clases.DatosServicio;
using WebAPI.Clases.HolidayContainer;
using WebAPI.Clases.XmlParser;

namespace WebAPI.Controllers;
[Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class MainController : ControllerBase {

    public readonly DataAccess dataAccess;


    public MainController(DataAccess d) {
        this.dataAccess = d;
    }

    ///// <summary>
    ///// Obtiene datos filtrando en función de los parámetros solicitados por el usuario
    ///// </summary>
    ///// <param name="feed">Datos de xml parseados</param>
    ///// <param name="idUser">correo del usuario del que se desean datos</param>
    ///// <param name="startDate">Fecha desde la que se cogen datos</param>
    ///// <param name="endDate">Fecha hasta la que se cogen datos</param>
    ///// <param name="estado">Estado de los dias que se desean obtener</param>
    ///// <returns></returns>
    private static List<Tuple<String, String, DateTime, DateTime>> GetFilteredUserData(feed feed,
                                                                                       string idUser,
                                                                                       DateTime startDate,
                                                                                       DateTime? endDate = null,
                                                                                       string estado = "Aprobada",
                                                                                       Func<List<feedEntry>, Object>? FuncionRepresentarCampos = null) {
        if (!endDate.HasValue) endDate = DateTime.Now;
        if (FuncionRepresentarCampos == null) FuncionRepresentarCampos = RepresentarCampos_Title_Estado_FechaInicio_FechaFin;
        //Filtro aquellas entradas que cumplan las condiciones
        List<feedEntry> ListaEntradas =
            feed.entry.Where(X =>
              X.content.properties.Title == idUser &&
              X.content.properties.Estado == estado &&
              X.content.properties.FechaInicio.Value > startDate &&
              X.content.properties.FechaFin.Value < endDate
            ).ToList(); 
        //Representación de los datos de respuesta quizas en un futuro necesite otros campos
        //De momento envio o una tupla: nombrePersona,EstadoVacaciones,FechaInicio,FechaFinal
        return RepresentarCampos_Title_Estado_FechaInicio_FechaFin(ListaEntradas);
    }

    ///// <summary>
    ///// Dada una lista de feedEntry devuelve la selección de los campos: Title,Estado,FechaInicio,FechaFinal
    ///// </summary>
    ///// <param name="ListaEntradas"></param>
    ///// <returns></returns>
    private static List<Tuple<String, String, DateTime, DateTime>> RepresentarCampos_Title_Estado_FechaInicio_FechaFin(List<feedEntry> ListaEntradas) =>
        ListaEntradas.Select(entrada =>
                             Tuple.Create(entrada.content.properties.Title,
                                          entrada.content.properties.Estado,
                                          entrada.content.properties.FechaInicio.Value,
                                          entrada.content.properties.FechaFin.Value
                             )
                    ).ToList();


    ///// <summary>
    ///// Metodo que comprueba la validez de los datos para devolver una respuesta HTTP
    ///// </summary>
    ///// <param name="ResultadosFiltro"></param>
    ///// <returns></returns>
    //private IActionResult ProcesarResultados(IEnumerable<Object> ResultadosFiltro) {
    //    //List < Tuple < String,String,DateTime,DateTime >>
    //    if (ResultadosFiltro == null) return BadRequest();
    //    if (!ResultadosFiltro.Any()) return NoContent();
    //    return Ok(JsonConvert.SerializeObject(ResultadosFiltro));
    //}

    /// <summary>
    /// Devuelve las vacaciones con un determinado estado en un intervalo de fechas
    /// </summary>
    /// <param name="idUser">Id del usuario</param>
    /// <param name="startDate">Comienzo vacaciones</param>
    /// <param name="endDate">Final Vacaciones</param>
    /// <param name="estado">Estadode las vacaciones</param>
    /// <returns></returns>
    [Microsoft.AspNetCore.Mvc.HttpGet("GetHolidayUserInDate/{idUser}/{startDate}/{endDate}")] 
    public IEnumerable<IHolidayDataContainer> GetHolidayUserInDate(string idUser, DateTime startDate, DateTime endDate, string estado = "Aprobada") {
        List<String> Results = new();
        try {
            feed feedTotalXML = dataAccess.GetAllData();
            List<Tuple<String, String, DateTime, DateTime>> DatosFiltrados = GetFilteredUserData(feedTotalXML, idUser, startDate, endDate, estado);
            IHolidayDataContainer containerInstance = new HolidayDataContainer_Title_Estado_DateI_DateF();    
            return containerInstance.GetContainers(DatosFiltrados) ;
        }
        catch (FormatException) { throw new FormatException("Parametros mal introducidos");  }
        catch (Exception) { throw new Exception("Error Inesperado") ; }
    }

    /// <summary>
    /// Devuelve todas las vacaciones de un usuario de cualquier tipo desde una fecha
    /// </summary>
    /// <param name="idUser">Id usuario</param>
    /// <param name="FechaDesde">Fecha desde la que se devolveran vacaciones </param>
    /// <returns></returns>
    [Microsoft.AspNetCore.Mvc.HttpGet("GetHolidayFromUser/{idUser}/{FechaDesde}")]
    public IEnumerable<IHolidayDataContainer> GetHolidayUser(string idUser, DateTime FechaDesde) {
        try {
            feed feedTotalXML = dataAccess.GetAllData();
            List<Tuple<String, String, DateTime, DateTime>> DatosFiltrados = GetFilteredUserData(feedTotalXML, idUser, FechaDesde);
            IHolidayDataContainer container = new HolidayDataContainer_Title_Estado_DateI_DateF();
            return container.GetContainers(DatosFiltrados);
        }
        catch (FormatException) { throw new FormatException("Parametros mal introducidos"); }
        catch (Exception) { throw new Exception("Error Inesperado") ; }
    }

    /// <summary>
    /// Devuelve todas las vacaciones del usario desde la fecha hasta la actualidad
    /// </summary>
    /// <param name="idUser">Id usuario</param>
    /// <param name="FechaDesde">Fecha desde la que se comenzaran a buscar las vacaciones</param>
    /// <returns></returns>
   
    [Microsoft.AspNetCore.Mvc.HttpGet("GetHolidaysUserTillNow/{idUser}/{FechaDesde}")]
    public IEnumerable<IHolidayDataContainer> GetHolidayUserFromDateTillNow(string idUser, DateTime FechaDesde) {
        try {

            feed feedTotalXML = dataAccess.GetAllData();
            List<Tuple<String, String, DateTime, DateTime>> DatosFiltrados = GetFilteredUserData(feedTotalXML, idUser, FechaDesde);
            IHolidayDataContainer dataContainer = new HolidayDataContainer_Title_Estado_DateI_DateF();
            return dataContainer.GetContainers(DatosFiltrados);
        }
        catch (FormatException) { throw new FormatException("Mal formato de los parámetros"); }
        catch (Exception) { throw new Exception("Error Inesperado"); }
    }


    /// <summary>
    /// Devuelve una lista agrupada por los usuarios con las vacaciones desde una fecha
    /// </summary>
    /// <param name="miembrosEquipo"></param>
    /// <param name="FechaDesde"></param>
    /// <returns></returns>
    [Microsoft.AspNetCore.Mvc.HttpPost("GetHolidaysTeam/{FechaDesde}")]
    public Dictionary<String,IEnumerable<IHolidayDataContainer>> GetTeamHolidays( [Microsoft.AspNetCore.Mvc.FromBody]List<String> miembrosEquipo, DateTime FechaDesde) {
        try {
            Dictionary<String, IEnumerable<IHolidayDataContainer>> UserHolidays = new ();
            feed feedTotalXML = dataAccess.GetAllData();
            miembrosEquipo.AsParallel().ToList().ForEach(personaEquipo => {
                
                List<Tuple<string,string,DateTime,DateTime>> diasUsuario= GetFilteredUserData(feedTotalXML, personaEquipo, FechaDesde);
                IHolidayDataContainer container = new HolidayDataContainer_Title_Estado_DateI_DateF();
                String personaTitle = diasUsuario.First().Item1;


                IEnumerable<IHolidayDataContainer> f = container.GetContainers(diasUsuario);
                UserHolidays[personaTitle]= container.GetContainers(diasUsuario);

            });
            return UserHolidays;
            
        }
        catch (FormatException) { throw new FormatException("Parametros mal introducidos"); }
        catch (Exception) { throw new Exception("Error inesperado"); }
    }
}




