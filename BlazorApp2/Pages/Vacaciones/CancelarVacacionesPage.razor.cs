namespace BlazorApp2.Pages.CancelarVacaciones;
public class CancelarVacacionesBase : ComponentBase {
    [Inject] protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject] protected API _api { get; set; }
    
    protected UsuarioResponse InfoUsuario;
    protected IEnumerable<CalendarioVacacionesResponse> Vacaciones { get; set; }
    protected IEnumerable<EstadoCalendarioVacacionesResponse> Estados { get; set; }

    protected override async Task OnInitializedAsync() {
        InfoUsuario = _authenticationStateProvider.GetCurrentUser(_api);
        var datosTotalVacaciones = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        Estados = await _api.GetAllEstadoCalendarioVacacionesAsync();
        this.Vacaciones = datosTotalVacaciones.Where(X => Estados.First(Y => Y.Id == X.Estado).Descripcion == "Aprobadas");
    }

    protected async Task BorrarDia(CalendarioVacacionesResponse order) {
        DeleteCalendarioVacacionesCommand c = MapFrom<CalendarioVacacionesResponse, DeleteCalendarioVacacionesCommand>.Map(order);
        await _api.DeleteCalendarioVacacionesAsync(c);
        var datosTotalVacaciones = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        Estados = await _api.GetAllEstadoCalendarioVacacionesAsync();

        this.Vacaciones = datosTotalVacaciones.Where(X => Estados.First(Y => Y.Id == X.Estado).Descripcion == "Aprobadas");

    }


}
