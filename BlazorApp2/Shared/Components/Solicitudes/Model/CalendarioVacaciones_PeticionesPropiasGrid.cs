namespace BlazorApp2.Pages.Peticiones.Solicitudes;

public static class MetodosExtension {
    public static CalendarioVacaciones_PeticionesPropiasGrid Convertir(this CalendarioVacacionesResponse c,
                                                         IEnumerable<EstadoCalendarioVacacionesResponse> estados, 
                                                         IEnumerable<TipoDiaCalendarioResponse> tipos) {
        CalendarioVacaciones_PeticionesPropiasGrid respuesta = new();
        respuesta.FechaCalendario = c.FechaCalendario.Date;
        respuesta.IdTecnico = c.IdTecnico;
        respuesta.TipoDiaCalendario = tipos.First(X => X.Id == c.TipoDiaCalendario).Descripcion;
        respuesta.Estado = estados.First(X => X.Id == c.Estado).Descripcion;
        return respuesta;
    }

    public static IEnumerable<CalendarioVacaciones_PeticionesPropiasGrid> ConvertirListado(
        this IEnumerable<CalendarioVacacionesResponse> calendarios, 
        IEnumerable<EstadoCalendarioVacacionesResponse> estados, 
        IEnumerable<TipoDiaCalendarioResponse> tipos) {
        var resultados = new List<CalendarioVacaciones_PeticionesPropiasGrid>();
        foreach (var item in calendarios) {
            resultados.Add(Convertir(item, estados, tipos));
        }
        return resultados;
    }

}

//Representa toda la información de un calendario para mostrar en datagrid
public class CalendarioVacaciones_PeticionesPropiasGrid {
    public int IdTecnico { get; set; }
    public DateTime FechaCalendario { get; set; }
    public String TipoDiaCalendario { get; set; }
    public String Estado { get; set; }

    public CalendarioVacacionesResponse Convertir(IEnumerable<EstadoCalendarioVacacionesResponse> estados, IEnumerable<TipoDiaCalendarioResponse> tipos) {
        CalendarioVacacionesResponse respuesta = new();
        respuesta.IdTecnico = this.IdTecnico;
        respuesta.FechaCalendario = DateTimeOffset.Parse(this.FechaCalendario.ToString());
        respuesta.TipoDiaCalendario = tipos.First(X => X.Descripcion == this.TipoDiaCalendario).Id;
        respuesta.Estado = estados.First(X => X.Descripcion == this.Estado).Id;
        return respuesta;
    }
}