namespace Application.Responses;

public class CalendarioVacacionesResponse {
    public int IdTecnico { get; set; }
    public DateTime FechaCalendario { get; set; }
    public int TipoDiaCalendario { get; set; }
    public int Estado { get; set; }

    
    public override string ToString() => $"IdTecnico:{IdTecnico} FechaCalendario:{FechaCalendario} TipoDiaCalendario:{TipoDiaCalendario}";
}

