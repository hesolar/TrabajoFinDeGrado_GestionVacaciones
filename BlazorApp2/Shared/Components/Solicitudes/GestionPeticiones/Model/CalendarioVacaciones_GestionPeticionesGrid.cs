namespace BlazorApp2.Pages.Peticiones.Solicitudes;

//Representa toda la información de un calendario para mostrar en datagrid
public class CalendarioVacaciones_GestionPeticionesGrid {
    public string Nombre{ get; set; }
    public string Apellido1{ get; set; }
    public string Apellido2{ get; set; }
    public string EmailCorporativo{ get; set; }
    public DateTime FechaCalendario { get; set; }
    public String TipoDiaCalendario { get; set; }
    public String Estado { get; set; }

    public CalendarioVacacionesResponse Convertir(IEnumerable<EstadoCalendarioVacacionesResponse> estados,IEnumerable<TipoDiaCalendarioResponse> tipos, UsuarioResponse usuario) {

        return new CalendarioVacacionesResponse() {
            IdTecnico = usuario.IdTecnico,
            FechaCalendario = DateTimeOffset.Parse(this.FechaCalendario.ToString()),
            TipoDiaCalendario = tipos.First(X => X.Descripcion == this.TipoDiaCalendario).Id,
            Estado = estados.First(X => X.Descripcion == this.Estado).Id
        };

    }
  
}