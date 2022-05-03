﻿
using BlazorApp2.Pages.Peticiones.Solicitudes;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp2.Pages.CancelarVacaciones;
public class CancelarVacacionesBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]
    protected API _api { get; set; }

    public UsuarioResponse InfoUsuario;
    public IEnumerable<CalendarioVacacionesResponse> Vacaciones { get; set; }
    public IEnumerable<EstadoCalendarioVacacionesResponse> Estados { get; set; }

    protected override async Task OnInitializedAsync() {
        InfoUsuario = _authenticationStateProvider.GetCurrentUser(_api);
        var datosTotalVacaciones = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        Estados = await _api.GetAllEstadoCalendarioVacacionesAsync();
        this.Vacaciones = datosTotalVacaciones.Where(X => Estados.First(Y => Y.Id == X.Estado).Descripcion == "Aprobadas");
    }

    public async Task BorrarDia(CalendarioVacacionesResponse order) {

        await _api.DeleteCalendarioVacacionesAsync(new DeleteCalendarioVacacionesCommand() {Fecha=order.FechaCalendario, UsuarioID=order.IdTecnico });
        var datosTotalVacaciones = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        Estados = await _api.GetAllEstadoCalendarioVacacionesAsync();

        this.Vacaciones = datosTotalVacaciones.Where(X => Estados.First(Y => Y.Id == X.Estado).Descripcion == "Aprobadas");

    }


}