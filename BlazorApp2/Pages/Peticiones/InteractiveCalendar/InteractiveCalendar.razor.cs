

namespace BlazorApp2.Pages.Peticiones.InteractiveCalendar;

public class InteractiveCalendarBase : ComponentBase {
    #region variables principales

    public Calendario CalendarioUsuario = new();
    public DatosDias diasCalendario;
    public Calendario CalendarioEmpresa;
    #endregion

    #region Variables utilizadas con fines "estéticos"
    //Estado de la seleccion

    [CascadingParameter(Name = "EstadoDiaSeleccion")]


    public String EstadoDiaSeleccion { get; set; }


    //Modo multiseleccion de dias
    [CascadingParameter(Name = "Multiseleccion")]
    public bool DayMultiseletionMode {get;set;}

    [Inject]
    protected API _api { get; set; }

    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }
    


    public Dictionary<string, string> EstadoDiaSelecciones;

    public static readonly String colorInicioMultiseleccion = "white";
    public static readonly String colorInicial = "none";
    public static readonly String colorOver = "blue";


    #endregion

   

    public InteractiveCalendarBase() {
        //todo actualizar los dias del calendario de la empresa q sean public holiday
        this.CalendarioUsuario.DiasCalendario = OperacionesCalendario.GenerarDiasCalendario(this.CalendarioUsuario.AñoCalendario);
        this.diasCalendario = this.CalendarioUsuario.DiasCalendario;
        //throw new NotImplementedException();
    }



    /// <summary>
    /// Permite seleccionar multiples dias a la vez con el estado de dia actual
    /// </summary>
    /// <param name="diasEnMultiseleccion">Conjunto de dias</param>
    /// <returns></returns>
    public bool SelectMultipleDays(DatosDias diasEnMultiseleccion) {

       OperacionesCalendario.AplyFilterToDays(diasEnMultiseleccion, new Action<DatoDia>(dia => SingleSelectionDay(dia)));
       return true;
          
        
        


    }
    //todo necesito restricciones de dominio
    /// <summary>
    /// Este metodo cuando esté hecho determinará si se puede actualizar un conjunto de dias
    /// </summary>
    /// <param name="diasEnMultiseleccion"></param>
    /// <returns></returns>
    private static bool CanUpdateAllDays(DatosDias diasEnMultiseleccion) => true;

    /// <summary>
    /// Este medodo permite seleccionar un dia con el estado de dia actual
    /// </summary>
    /// <param name="dia">Dia que se va a seleccionar</param>
    /// <param name="multiseleccion">Indica si el modo multiseleccion está activo</param>
    /// <returns></returns>
    public bool SingleSelectionDay(DatoDia dia, bool multiseleccion = false) {
            //Primero limpiar la seleccion anterior(si es que estamos en multiseleccion)
            if (!multiseleccion) {
                dia.Estado = this.EstadoDiaSeleccion;
                dia.ColorSeleccion = this.EstadoDiaSelecciones[this.EstadoDiaSeleccion];
                return true;
                //Core_Calendario.AplyFilterToDays(this.diasCalendario, new(dia => dia.Estado = this.EstadoDiaSeleccion));
            }
            //Actualizar el calendario , si es posible retorno true
            //return Core_Calendario.ActualizarCalendario(this.diasCalendario, dia, EstadoDiaSeleccion);
        //no se puede seleccioanr el dia con ese estado
        return false;
    }

    protected override async Task OnAfterRenderAsync(bool firstRender) {

        if (firstRender) {

            var tiposDias = await _api.GetAllTipoDiaCalendarioAsync();
            this.EstadoDiaSelecciones = tiposDias.ToDictionary(keySelector: m => m.Descripcion, elementSelector: m => m.ColorRepresentacion);

            var vacaciones = await _api.GetAllCalendarioVacacionesAsync();
            vacaciones.ToList().ForEach(x => {


                var dia = this.CalendarioUsuario.DiasCalendario.FirstOrDefault(y => x.FechaCalendario == y.Date);
                if (dia != null) {
                    var tipoDia = tiposDias.First(y => y.Id == x.TipoDiaCalendario);
                    dia.ColorSeleccion = tipoDia.ColorRepresentacion;
                    dia.Estado = tipoDia.Descripcion;

                }

            });
            StateHasChanged();
        }

    }





    #region Event Listeners

    //todo revisar cuando tenga las especificaciones
    /// <summary>
    /// Dado un mes selecciona todos los dias(Laborables) de ese mes y los marca como el estado de dia seleccionado.
    /// Los dias de vacaciones pactados por la empresa no se podrán cambiar.
    /// </summary>
    /// <param name="dias"></param>
    /// <returns></returns>
    public bool SelectAllMonthButtonListener(DatosDias dias) {
        return SelectMultipleDays(new DatosDias(dias));
    }

    public void SelectDay(DatoDia d) => DaySelectorEventListener(d);

    //Gestion de la seleccion de dias
    public bool DaySelectorEventListener(DatoDia dia) {
        return this.DayMultiseletionMode ?
            MultiSelectionDay(dia)
            : SingleSelectionDay(dia);
    }


    public bool MultiSelectionDay(DatoDia dia) {
        //Establece el primer dia para la multiseleccion si no hay ningún boton ya seleccionado
        if (OperacionesCalendario.NingunDiaFiltro(this.diasCalendario, new Func<DatoDia, bool>(dia => dia.ColorSeleccion == colorInicioMultiseleccion))) {
            dia.ColorSeleccion = colorInicioMultiseleccion;
            return true;
        }

        //Si ya existe un primer dia de multiseleecion, este click marca el final de la multiseleccion
        if (OperacionesCalendario.NumeroDiasFiltro(this.diasCalendario, new Func<DatoDia, bool>(dia => dia.ColorSeleccion == colorInicioMultiseleccion)) > 0) {
            //this.DayMultiseletionMode = false;

            //Devuelve el resultado de hacer multiseleccion en los dias
            return SelectMultipleDays(
                new DatosDias(OperacionesCalendario.FiltroDia(this.diasCalendario, new(dia => dia.ColorSeleccion == colorInicioMultiseleccion || dia.ColorSeleccion == colorOver))
            ));
        }
        //si no ha devuelto nada es que ha habido algun tipo de error
        return false;
    }






    /// <summary>
    /// Este metodo colorea el dia en el calendario si no estaba seleccionado, si estaba seleccionado lo deselecciona.
    /// Hay que tener en cuenta que no se podrá colorear el boton de inicio de la multiseleccion y que el modo de multiseleccion deberá estar activo
    /// </summary>
    /// <param name="dia"></param>
    public void OverButtonListener(DatoDia dia) {
        if (this.DayMultiseletionMode && !OperacionesCalendario.NingunDiaFiltro(this.diasCalendario, new(dia => dia.ColorSeleccion == colorInicioMultiseleccion))
            && !OperacionesCalendario.NingunDiaFiltro(this.diasCalendario, new(dia => dia.ColorSeleccion == colorInicial))
            && dia.ColorSeleccion != colorInicioMultiseleccion)
            //dia.ColorSeleccion = dia.ColorSeleccion == colorOver ? colorInicial : colorOver;            
            dia.ColorSeleccion = colorOver;
    }

    //todo if(validarDatosCalendario(this.diasCalendario))//  CalendarioUsuario.DiasCalendario = this.diasCalendario;
    /// <summary>
    /// Boton de guardar datos del calendario
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SaveCalendarButtonListener() {
        var tiposDias = await _api.GetAllTipoDiaCalendarioAsync();
        this.EstadoDiaSelecciones = tiposDias.ToDictionary(keySelector: m => m.Descripcion, elementSelector: m => m.ColorRepresentacion);
        var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
        var userIdentity = authState.User.Identity.Name;
        var usuario = await _api.GetUsuarioByCorreoEmpresaAsync(userIdentity);

        //cambiar
        var vacaciones = await _api.GetAllCalendarioVacacionesAsync();
        //var vacaciones = await _api.GetCalendarioVacacionesByIdAsync(usuario.IdTecnico, this.diasCalendario.First().Date.AddYears(-5));

        var diasBorrar = this.diasCalendario.Where(x => vacaciones.Any(X => X.FechaCalendario == x.Date) && x.Estado == "Laborable");
        var listadoEnBDYTrabajados = diasCalendario.Where(X => vacaciones.Any(y => X.Date == y.FechaCalendario) || X.Estado == "Laborable");
        var nuevosDias = this.diasCalendario.Except(listadoEnBDYTrabajados);




        foreach (var dia in nuevosDias) {
            var tipoDia = tiposDias.First(x => x.ColorRepresentacion == dia.ColorSeleccion).Id;
            await _api.CreateCalendarioVacacionesAsync(new CreateCalendarioVacacionesCommand() { FechaCalendario = dia.Date, IdTecnico = usuario.IdTecnico, TipoDiaCalendario = tipoDia });
        }


        foreach (var diaBorrar in diasBorrar) {

            await _api.DeleteCalendarioVacacionesAsync(new DeleteCalendarioVacacionesCommand() {
                Fecha = diaBorrar.Date,
                UsuarioID = usuario.IdTecnico
            });
        }

        await OnAfterRenderAsync(true);

    }


    //todo
    /// <summary>
    /// Boton de salir sin guardar
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public async Task ExitButtonListener() {
        await OnAfterRenderAsync(true);
    }

    #endregion
}







