namespace BlazorApp2.Pages.Peticiones.Solicitudes;

    public static class MetodosExtension {
        public static CalendarioVacacionesCompleto Convertir(this CalendarioVacacionesResponse c, 
IEnumerable<EstadoCalendarioVacacionesResponse> estados, IEnumerable<TipoDiaCalendarioResponse> tipos) {
            CalendarioVacacionesCompleto respuesta = new();
            respuesta.FechaCalendario = c.FechaCalendario.Date;
            respuesta.IdTecnico = c.IdTecnico;
            respuesta.TipoDiaCalendario = tipos.First(X => X.Id == c.TipoDiaCalendario).Descripcion;
            respuesta.Estado = estados.First(X => X.Id == c.Estado).Descripcion;
            return respuesta;
        }



        public static IEnumerable<CalendarioVacacionesCompleto> ConvertirListado(this IEnumerable<CalendarioVacacionesResponse> calendarios, IEnumerable<EstadoCalendarioVacacionesResponse> estados, IEnumerable<TipoDiaCalendarioResponse> tipos) {
            var resultados=  new List<CalendarioVacacionesCompleto>();
            foreach (var item in calendarios) {
                resultados.Add(Convertir(item, estados, tipos));
            }
            return resultados;
        }


      
    }

    //Representa toda la información de un calendario
    public class CalendarioVacacionesCompleto {
        public int IdTecnico { get; set; }
        public DateTime FechaCalendario { get; set; }
        public String TipoDiaCalendario { get; set; }
        public String Estado { get; set; }

        public  CalendarioVacacionesResponse Convertir( IEnumerable<EstadoCalendarioVacacionesResponse> estados, IEnumerable<TipoDiaCalendarioResponse> tipos) {
            CalendarioVacacionesResponse respuesta = new();
            respuesta.IdTecnico = this.IdTecnico;
            respuesta.FechaCalendario = DateTimeOffset.Parse( this.FechaCalendario.ToString());
            respuesta.TipoDiaCalendario = tipos.First(X => X.Descripcion == this.TipoDiaCalendario).Id;
            respuesta.Estado = estados.First(X => X.Descripcion == this.Estado).Id;
            return respuesta;
        }
    }