namespace BlazorApp2.Pages; 
public class PeticionesVacacionesBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    protected API api { get; set; }

    protected IEnumerable<CalendarioVacacionesResponse> CalendarioVacacionesUsuario { get; set; } = new List<CalendarioVacacionesResponse>();
    protected UsuarioResponse _selfEmployee { get; set; }



}
