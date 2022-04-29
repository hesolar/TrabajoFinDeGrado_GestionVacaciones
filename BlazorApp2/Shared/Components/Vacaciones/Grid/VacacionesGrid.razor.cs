
using BlazorApp2.Pages.Peticiones.Solicitudes;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp2.Pages;
public class VacacionesGridBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]
    protected API _api { get; set; }

    [Parameter]
    public EventCallback ChangeBackwardsCallback { get; set; }


    protected UsuarioResponse InfoUsuario { get; set; }

    protected IEnumerable<CalendarioVacaciones_PeticionesPropiasGrid> CalendarioVacacionesUsuario { get; set; } = new List<CalendarioVacaciones_PeticionesPropiasGrid>();

    protected RadzenDataGrid<CalendarioVacaciones_PeticionesPropiasGrid> ComponentePrincipal;

    public  IEnumerable<TipoDiaCalendarioResponse> TipoDiaCalendarioVaciones;
    public  IEnumerable<EstadoCalendarioVacacionesResponse> EstadosCalendario;




    /// <summary>
    /// Metodo que se iniciará automaticamente al iniciarse la componente
    /// Obtiene información del usuario actual
    /// </summary>
    /// <returns></returns>

    protected override async Task OnParametersSetAsync() {
        EstadosCalendario=await _api.GetAllEstadoCalendarioVacacionesAsync();
        TipoDiaCalendarioVaciones=await _api.GetAllTipoDiaCalendarioAsync();
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity.Name;
        InfoUsuario = await _api.GetUsuarioByCorreoEmpresaAsync(userIdentity);
    }

    /// <summary>
    /// Activa el proceso de carga de datos desde la api al componente principal,mostramos las peticiones no aprobadas
    /// </summary>
    /// <returns></returns>
    protected async Task LoadData() {
        ComponentePrincipal.IsLoading = true;
        ComponentePrincipal.Reset(true);
        await ComponentePrincipal.FirstPage(true);
        StateHasChanged();
        IEnumerable<CalendarioVacacionesResponse> datos = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        int estadoAprobado = this.EstadosCalendario.First(X => X.Descripcion == "Aprobadas").Id;
        datos = datos.Where(X => X.Estado == estadoAprobado);

        CalendarioVacacionesUsuario = datos.ConvertirListado(this.EstadosCalendario,this.TipoDiaCalendarioVaciones);
        ComponentePrincipal.IsLoading = false;
        await ChangeBackwardsCallback.InvokeAsync();
    }




 

}
