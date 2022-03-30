
namespace Application.Operations.Commands;

public class CreateCalendarioVacacionesCommand : IRequest<bool> {

    public int IdTecnico { get; set; }
    public DateTime FechaCalendario { get; set; }
    public int TipoDiaCalendario { get; set; }

}