
namespace Application.Operations.Commands;

public class UpdateCalendarioVacacionesCommand : IRequest<bool>{
    public int IdTecnico { get; set; }

    public DateTime FechaCalendario { get; set; }
    public int TipoDiaCalendario { get; set; } 

    public int Estado { get; set; }
}

