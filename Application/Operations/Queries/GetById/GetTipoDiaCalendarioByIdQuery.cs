namespace Application.Operations.Queries;

public class GetTipoDiaCalendarioByIdQuery: IRequest<TipoDiaCalendarioResponse> {
    public int Id { get; set; }
}

