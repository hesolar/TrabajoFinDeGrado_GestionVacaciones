
using BlazorApp2.Pages.Peticiones.Solicitudes;
using Microsoft.AspNetCore.Components.Web;

namespace BlazorApp2.Pages;
public class SolicitudesPropiasBase : ComponentBase {

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]
    protected API _api { get; set; }

    protected UsuarioResponse InfoUsuario { get; set; }

    protected IEnumerable<CalendarioVacacionesCompleto> CalendarioVacacionesUsuario { get; set; } = new List<CalendarioVacacionesCompleto>();

    protected RadzenDataGrid<CalendarioVacacionesCompleto> ComponentePrincipal;
    protected CalendarioVacacionesCompleto? ValorAuxiliarEdicion;

    public  IEnumerable<TipoDiaCalendarioResponse> TipoDiaCalendarioVaciones;
    public  IEnumerable<EstadoCalendarioVacacionesResponse> EstadosCalendario;


    //Gestor Errores
    protected ErrorBoundary ErrorBoundaryBorradosModificaciones;
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;



    /// <summary>
    /// Metodo que se iniciará automaticamente al iniciarse la componente
    /// Obtiene información del usuario actual
    /// </summary>
    /// <returns></returns>

    protected override async Task OnInitializedAsync() {
        EstadosCalendario=await _api.GetAllEstadoCalendarioVacacionesAsync();
        TipoDiaCalendarioVaciones=await _api.GetAllTipoDiaCalendarioAsync();

        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity.Name;
        InfoUsuario = await _api.GetUsuarioByCorreoEmpresaAsync(userIdentity);
    }

    /// <summary>
    /// Guarda el resultado de guardar un calendario si este ha cambiado
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task SaveRow(CalendarioVacacionesCompleto order) {
        //Comprobamos si ha cambiado el valor de edicion
        if (ValorAuxiliarEdicion!=null) {
            //Si tienen distinto valor actualizamos
            if (order.FechaCalendario != ValorAuxiliarEdicion?.FechaCalendario) {
                await _api.ReplaceCalendarioVacacionesAsync(new ReplaceCalendarioVacacionesCommand() {
                    FechaCalendarioNew = order.FechaCalendario,
                    TipoDiaCalendarioNew = this.TipoDiaCalendarioVaciones.First(x=> x.Descripcion==order.TipoDiaCalendario).Id,
                    FechaCalendarioOld = ValorAuxiliarEdicion.FechaCalendario,
                    IdTecnico = order.IdTecnico,
                    TipoDiaCalendarioOld = this.TipoDiaCalendarioVaciones.First(x => x.Descripcion == order.TipoDiaCalendario).Id
                }) ;
            }
            //Sino lo insertamos a la bd
            else {
                await _api.CreateCalendarioVacacionesAsync(new CreateCalendarioVacacionesCommand() {
                    FechaCalendario = order.FechaCalendario,
                    IdTecnico = order.IdTecnico,
                    TipoDiaCalendario = this.TipoDiaCalendarioVaciones.First(x => x.Descripcion == order.TipoDiaCalendario).Id
                }); ;
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
    public async Task EditRow(CalendarioVacacionesCompleto OldCalendarioVacaciones) {
        ValorAuxiliarEdicion = new();
        PropertyCopier<CalendarioVacacionesCompleto, CalendarioVacacionesCompleto>.Copy(OldCalendarioVacaciones, ValorAuxiliarEdicion);
        await ComponentePrincipal.EditRow(OldCalendarioVacaciones);
    }
    /// <summary>
    /// Eliminar una fila del grid
    /// </summary>
    /// <param name="calendarioAEliminar"></param>
    /// <returns></returns>
    public async Task DeleteRow(CalendarioVacacionesCompleto calendarioAEliminar) {
        await _api.DeleteCalendarioVacacionesAsync(new DeleteCalendarioVacacionesCommand() {
            Fecha = calendarioAEliminar.FechaCalendario,
            UsuarioID = calendarioAEliminar.IdTecnico
        });
        this.CalendarioVacacionesUsuario.ToList().Remove(calendarioAEliminar);
        await ComponentePrincipal.Reload();
        await LoadData();

    }

    /// <summary>
    /// Se cancela la edicion de la linea
    /// </summary>
    /// <param name="CalendarioEditado">Valor que no se aplicará la edicion</param>
    /// <returns></returns>
    public async Task CancelEdit(CalendarioVacacionesCompleto CalendarioEditado) {
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

        CalendarioVacacionesCompleto calendarioNuevo = new() {
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
        await Task.Delay(600);
        ComponentePrincipal.Reset(true);
        await ComponentePrincipal.FirstPage(true);
        IEnumerable<CalendarioVacacionesResponse> c= await _api.GetUsuarioCalendarioVacacionesAsync(InfoUsuario.IdTecnico);
         CalendarioVacacionesUsuario= c.ConvertirListado(this.EstadosCalendario,this.TipoDiaCalendarioVaciones);
        ComponentePrincipal.IsLoading = false;
        StateHasChanged();
    }

    protected void RecoverAppState() {
        if (ErrorBoundaryInsercionesNomodificaciones != null && ErrorBoundaryInsercionesNomodificaciones.ErrorContent != null) ErrorBoundaryInsercionesNomodificaciones.Recover();
        if (ErrorBoundaryBorradosModificaciones != null && ErrorBoundaryBorradosModificaciones.ErrorContent != null) ErrorBoundaryBorradosModificaciones.Recover();
      
    }

}
