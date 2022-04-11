
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp2.Pages;
public class PeticionesVacacionesPropiasBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]
    protected API _api { get; set; }

    protected UsuarioResponse InfoUsuario { get; set; }

    protected IEnumerable<CalendarioVacacionesResponse> CalendarioVacacionesUsuario { get; set; } = new List<CalendarioVacacionesResponse>();

    protected RadzenDataGrid<CalendarioVacacionesResponse> ComponentePrincipal;
    protected CalendarioVacacionesResponse? ValorAuxiliarEdicion;

    //Gestor Errores
    protected ErrorBoundary ErrorBoundaryBorradosModificaciones;
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;



    /// <summary>
    /// Metodo que se iniciará automaticamente al iniciarse la componente
    /// Obtiene información del usuario actual
    /// </summary>
    /// <returns></returns>

    protected override async Task OnInitializedAsync() {
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity.Name;
        InfoUsuario = await _api.GetUsuarioByCorreoEmpresaAsync(userIdentity);
    }

    /// <summary>
    /// Guarda el resultado de guardar un calendario si este ha cambiado
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task SaveRow(CalendarioVacacionesResponse order) {
        //Comprobamos si ha cambiado el valor de edicion
        if (ValorAuxiliarEdicion!=null) {
            //Si tienen distinto valor actualizamos
            if (order.FechaCalendario != ValorAuxiliarEdicion?.FechaCalendario) {
                await _api.ReplaceCalendarioVacacionesAsync(new ReplaceCalendarioVacacionesCommand() {
                    FechaCalendarioNew = order.FechaCalendario,
                    TipoDiaCalendarioNew = order.TipoDiaCalendario,
                    FechaCalendarioOld = ValorAuxiliarEdicion.FechaCalendario,
                    IdTecnico = order.IdTecnico,
                    TipoDiaCalendarioOld = order.TipoDiaCalendario
                }) ;
            }
            //Sino lo insertamos a la bd
            else { 
                await _api.CreateCalendarioVacacionesAsync(new CreateCalendarioVacacionesCommand() {
                    FechaCalendario = order.FechaCalendario,
                    IdTecnico = order.IdTecnico,
                    TipoDiaCalendario = order.TipoDiaCalendario
                });
            }

            
            await LoadData();
        }
        //Sino cancelo la edicion
        else {
            ComponentePrincipal.CancelEditRow(order);
        }
    }

    /// <summary>
    /// Editar fila del grid, para ello guardamos los valores antiguos en el objeto de edicion calendario 
    /// por si hay que hacer rollaback en la edicion
    /// </summary>
    /// <param name="OldCalendarioVacaciones"></param>
    /// <returns></returns>
    public async Task EditRow(CalendarioVacacionesResponse OldCalendarioVacaciones) {
        ValorAuxiliarEdicion = new();
        PropertyCopier<CalendarioVacacionesResponse, CalendarioVacacionesResponse>.Copy(OldCalendarioVacaciones, ValorAuxiliarEdicion);
        await ComponentePrincipal.EditRow(OldCalendarioVacaciones);
    }
    /// <summary>
    /// Eliminar una fila del grid
    /// </summary>
    /// <param name="calendarioAEliminar"></param>
    /// <returns></returns>
    public async Task DeleteRow(CalendarioVacacionesResponse calendarioAEliminar) {
        await _api.DeleteCalendarioVacacionesAsync(new DeleteCalendarioVacacionesCommand() {
            Fecha = calendarioAEliminar.FechaCalendario,
            UsuarioID = calendarioAEliminar.IdTecnico
        });
        this.CalendarioVacacionesUsuario.ToList().Remove(calendarioAEliminar);
        await ComponentePrincipal.Reload();

    }

    /// <summary>
    /// Se cancela la edicion de la linea
    /// </summary>
    /// <param name="CalendarioEditado">Valor que no se aplicará la edicion</param>
    /// <returns></returns>
    public async Task CancelEdit(CalendarioVacacionesResponse CalendarioEditado) {
        if (ValorAuxiliarEdicion != null) CalendarioEditado.FechaCalendario = ValorAuxiliarEdicion.FechaCalendario;
        ValorAuxiliarEdicion = null;
        ComponentePrincipal.CancelEditRow(CalendarioEditado);
        //if (this.CalendarioVacacionesUsuario.Any()) await LoadData();
    }

    /// <summary>
    /// Se inserta una nueva fila en el grid de datos con el id del usuario y la fecha actual
    /// </summary>
    /// <returns></returns>
    public async Task InsertRow() {

        CalendarioVacacionesResponse calendarioNuevo = new() {
            IdTecnico = InfoUsuario.IdTecnico,
            FechaCalendario = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)
        };
        this.ValorAuxiliarEdicion = calendarioNuevo;
        await ComponentePrincipal.InsertRow(calendarioNuevo);
        StateHasChanged();
    }

    /// <summary>
    /// Activa el proceso de carga de datos desde la api al componente principal
    /// </summary>
    /// <returns></returns>
    protected async Task LoadData() {
        ComponentePrincipal.IsLoading = true;
        ComponentePrincipal.Reset(true);
        await ComponentePrincipal.FirstPage(true);
        CalendarioVacacionesUsuario = await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
        ComponentePrincipal.IsLoading = false;
        StateHasChanged();
    }

    protected void RecoverAppState() {
        if (ErrorBoundaryInsercionesNomodificaciones != null && ErrorBoundaryInsercionesNomodificaciones.ErrorContent != null) ErrorBoundaryInsercionesNomodificaciones.Recover();
        if (ErrorBoundaryBorradosModificaciones != null && ErrorBoundaryBorradosModificaciones.ErrorContent != null) ErrorBoundaryBorradosModificaciones.Recover();
      
    }

}
