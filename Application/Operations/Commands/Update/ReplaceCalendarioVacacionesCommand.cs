
namespace Application.Operations.Commands;

public class ReplaceCalendarioVacacionesCommand : IRequest<bool> {
    public int IdTecnico { get; set; }

    public DateTime FechaCalendarioOld { get; set; }
    public DateTime FechaCalendarioNew { get; set; }
    public int TipoDiaCalendarioOld { get; set; }
    public int TipoDiaCalendarioNew { get; set; }



}



