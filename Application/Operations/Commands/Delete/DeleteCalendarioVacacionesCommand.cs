namespace Application.Operations.Commands;
public class DeleteCalendarioVacacionesCommand : IRequest<bool> {

    public int UsuarioID { get; set; }
    public DateTime Fecha { get; set; }

}
