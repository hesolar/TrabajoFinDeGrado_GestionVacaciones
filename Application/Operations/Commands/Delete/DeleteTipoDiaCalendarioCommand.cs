namespace Application.Operations.Commands;
public class DeleteTipoDiaCalendarioCommand : IRequest<bool> {

    public int Id { get; set; }

}
