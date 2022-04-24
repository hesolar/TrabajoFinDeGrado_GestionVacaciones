using BlazorApp2.Pages.Peticiones.Solicitudes;

namespace BlazorApp2.Shared.Components.Solicitudes.Model; 
public class GestionPeticionesBase: ComponentBase {

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    [Inject]
    protected API _api { get; set; }

    [Parameter]
    public EventCallback ChangeBackwardsCallback { get; set; }



    protected UsuarioResponse InfoUsuario { get; set; }

    protected IEnumerable<CalendarioVacaciones_GestionPeticionesGrid> CalendarioVacacionesUsuario { get; set; } = new List<CalendarioVacaciones_GestionPeticionesGrid>();

    protected RadzenDataGrid<CalendarioVacaciones_GestionPeticionesGrid> ComponentePrincipal;
    protected CalendarioVacaciones_GestionPeticionesGrid? ValorAuxiliarEdicion;

    public IEnumerable<TipoDiaCalendarioResponse> TipoDiaCalendarioVaciones;
    public IEnumerable<EstadoCalendarioVacacionesResponse> EstadosCalendario;

    //Gestor Errores
    protected ErrorBoundary ErrorBoundaryBorradosModificaciones;
    protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;



    /// <summary>
    /// Metodo que se iniciará automaticamente al iniciarse la componente
    /// Obtiene información del usuario actual
    /// </summary>
    /// <returns></returns>

    protected override async Task OnInitializedAsync() {
        EstadosCalendario = await _api.GetAllEstadoCalendarioVacacionesAsync();
        TipoDiaCalendarioVaciones = await _api.GetAllTipoDiaCalendarioAsync();
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity.Name;
        InfoUsuario = await _api.GetUsuarioByCorreoEmpresaAsync(userIdentity);
    }

    /// <summary>
    /// Guarda el resultado de guardar un calendario si este ha cambiado
    /// </summary>
    /// <param name="order"></param>
    /// <returns></returns>
    public async Task SaveRow(CalendarioVacaciones_GestionPeticionesGrid order) {
        //Comprobamos si ha cambiado el valor de edicion
        var usuario = await _api.GetUsuarioByCorreoEmpresaAsync(order.EmailCorporativo);
        if (ValorAuxiliarEdicion != null) {
            //Si tienen distinto valor actualizamos

            if (order.Estado != ValorAuxiliarEdicion.Estado)
               await _api.UpdateCalendarioVacacionesAsync(new UpdateCalendarioVacacionesCommand() {
                    FechaCalendario = order.FechaCalendario,
                    IdTecnico = usuario.IdTecnico,
                    Estado = this.EstadosCalendario.First(X => X.Descripcion == order.Estado).Id,
                    TipoDiaCalendario = this.TipoDiaCalendarioVaciones.First(X=> X.Descripcion==order.TipoDiaCalendario).Id
                }); 
              
            
            //Sino lo insertamos a la bd
            else {


                await _api.CreateCalendarioVacacionesAsync(new CreateCalendarioVacacionesCommand() {
                    FechaCalendario = order.FechaCalendario,
                    IdTecnico = usuario.IdTecnico,
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
    public async Task EditRow(CalendarioVacaciones_GestionPeticionesGrid OldCalendarioVacaciones) {
        ValorAuxiliarEdicion = new();
        PropertyCopier<CalendarioVacaciones_GestionPeticionesGrid, CalendarioVacaciones_GestionPeticionesGrid>.Copy(OldCalendarioVacaciones, ValorAuxiliarEdicion);
        await ComponentePrincipal.EditRow(OldCalendarioVacaciones);
    }

    /// <summary>
    /// Se cancela la edicion de la linea
    /// </summary>
    /// <param name="CalendarioEditado">Valor que no se aplicará la edicion</param>
    /// <returns></returns>
    public async Task CancelEdit(CalendarioVacaciones_GestionPeticionesGrid CalendarioEditado) {
        if (ValorAuxiliarEdicion != null) CalendarioEditado.FechaCalendario = ValorAuxiliarEdicion.FechaCalendario;
        ValorAuxiliarEdicion = null;
        ComponentePrincipal.CancelEditRow(CalendarioEditado);
        //if (this.CalendarioVacacionesUsuario.Any()) await LoadData();
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
       
       ( IEnumerable<CalendarioVacacionesResponse> respuesta,IEnumerable<UsuarioResponse> usuarios) =await ObtenerVacacionesSubordinados();

        this.CalendarioVacacionesUsuario = respuesta.ConvertirListado(usuarios, this.EstadosCalendario, this.TipoDiaCalendarioVaciones)
            .Where(X => X.Estado != "Cancelado" && X.Estado != "Aprobado"); ;


        //CalendarioVacacionesUsuario = c.ConvertirListado(this.EstadosCalendario, this.TipoDiaCalendarioVaciones);
        ComponentePrincipal.IsLoading = false;
        await ChangeBackwardsCallback.InvokeAsync();
        StateHasChanged();
    }


    //todo cambiar llamada solo con el usuario
    public async Task<(IEnumerable<CalendarioVacacionesResponse>,IEnumerable<UsuarioResponse>)> ObtenerVacacionesSubordinados() {
        //usuario activo
        var usuario = _authenticationStateProvider.GetCurrentUser(_api);
        //
        IEnumerable<int> proyectosUsuario = await _api.GetProyectosUsuarioAsync(usuario.IdTecnico);
        //GetCalendarioVacacionesSubordinados
        IEnumerable<CalendarioVacacionesResponse> vacaciones = await _api.GetCalendarioVacacionesSubordinadosAsync(usuario.WebRol, usuario.IdTecnico, proyectosUsuario);

        List<UsuarioResponse> usuarios= new();
        foreach (CalendarioVacacionesResponse c in vacaciones) {
            usuarios.Add(await _api.GetUsuarioByIdAsync(c.IdTecnico));
        }


        return (vacaciones,usuarios);

    }


    protected void RecoverAppState() {
        if (ErrorBoundaryInsercionesNomodificaciones != null && ErrorBoundaryInsercionesNomodificaciones.ErrorContent != null) ErrorBoundaryInsercionesNomodificaciones.Recover();
        if (ErrorBoundaryBorradosModificaciones != null && ErrorBoundaryBorradosModificaciones.ErrorContent != null) ErrorBoundaryBorradosModificaciones.Recover();

    }

}
