namespace BlazorApp2.Pages; 
public class PeticionesVacacionesBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject]
    protected API api { get; set; }


}
