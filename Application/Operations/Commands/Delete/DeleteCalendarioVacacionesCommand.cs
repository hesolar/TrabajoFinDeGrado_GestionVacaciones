namespace Application.Operations.Commands;
public class DeleteCalendarioVacacionesCommand : IRequest<bool> {

    public int IdTecnico { get; set; }
    public DateTime FechaCalendario { get; set; }

}
