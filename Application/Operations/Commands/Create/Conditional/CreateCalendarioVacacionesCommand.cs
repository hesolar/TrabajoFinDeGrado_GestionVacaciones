
namespace Application.Operations.Commands;

public class AddNonSavedCalendarioVacacionesCommand : IRequest<IEnumerable<CalendarioVacacionesResponse>> {

    public IEnumerable<CalendarioVacacionesResponse> nuevosDias {get; set;}

}