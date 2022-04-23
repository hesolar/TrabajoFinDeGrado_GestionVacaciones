


namespace BlazorApp2.Pages.Peticiones.InteractiveCalendar;

public class InteractiveCalendarBase : ComponentBase {
    #region variables principales

    //Dias Calendario
    public DatosDias diasCalendario;

    //Estado de la seleccion
    [CascadingParameter(Name = "EstadoDiaSeleccion")]
    public String EstadoDiaSeleccion { get; set; }

    //Modo multiseleccion de dias
    [CascadingParameter(Name = "Multiseleccion")]
    public bool DayMultiseletionMode { get; set; }

    //Api proyecto
    [Inject]
    protected API _api { get; set; }

    //Gestión Sesión, usuario actual
    [Inject]
    protected AuthenticationStateProvider _authenticationStateProvider { get; set; }


    //Estados de las selecciones, representa un estado de dia y su color => Laboral, azul
    public Dictionary<string, string> TipoDiaColor = new();



    #endregion


    //Generar todos los dias del calendario
    public InteractiveCalendarBase() {
        this.diasCalendario = OperacionesCalendario.GenerarDiasCalendario(DateTime.Now.Year);
    }



    /// <summary>
    /// Permite seleccionar multiples dias a la vez con el estado de dia actual
    /// </summary>
    /// <param name="diasEnMultiseleccion">Conjunto de dias</param>
    /// <returns></returns>
    public void SelectMultipleDays(DatosDias diasEnMultiseleccion)
       => OperacionesCalendario.AplyFilterToDays(diasEnMultiseleccion, new Action<DatoDia>(dia => SingleSelectionDay(dia)));




    /// <summary>
    /// Este medodo permite seleccionar un dia con el estado de dia actual
    /// </summary>
    /// <param name="dia">Dia que se va a seleccionar</param>
    /// <param name="multiseleccion">Indica si el modo multiseleccion está activo</param>
    /// <returns></returns>
    public bool SingleSelectionDay(DatoDia dia, bool multiseleccion = false) {
        if (!multiseleccion) {
            dia.TipoDia = this.EstadoDiaSeleccion;
            dia.ColorSeleccion = this.TipoDiaColor[this.EstadoDiaSeleccion];
            return true;
            //Core_Calendario.AplyFilterToDays(this.diasCalendario, new(dia => dia.Estado = this.EstadoDiaSeleccion));
        }
        //Actualizar el calendario , si es posible retorno true
        //no se puede seleccioanr el dia con ese estado
        return false;
    }


    /// <summary>
    /// Se cargan los datos de la bd: (dias y sus estado) , finalmente se llama al método para actualizar el calendario
    /// </summary>
    /// <param name="firstRender">primer renderizado de la app</param>
    /// <returns></returns>
    protected override async Task OnAfterRenderAsync(bool firstRender) {
        //Si es first render es decir que es la primera vez que se carga la página
        if (firstRender) {
            var usuarioActual = this._authenticationStateProvider.GetCurrentUser(_api);
            var vacaciones = await _api.GetUsuarioCalendarioVacacionesAsync(usuarioActual.IdTecnico);
            IEnumerable<TipoDiaCalendarioResponse> tiposDias = await _api.GetAllTipoDiaCalendarioAsync();
            this.TipoDiaColor = tiposDias.ToDictionary(keySelector: m => m.Descripcion, elementSelector: m => m.ColorRepresentacion);
            ActualizarDiasCalendario(vacaciones, tiposDias);
        }
    }

    /// <summary>
    /// Dado un conjunto de vacaciones y sus estados se actualiza el calendario
    /// </summary>
    /// <param name="vacaciones"></param>
    /// <param name="tiposDias"></param>
    /// <returns></returns>
    public void ActualizarDiasCalendario(IEnumerable<CalendarioVacacionesResponse> vacaciones,
                                          IEnumerable<TipoDiaCalendarioResponse> tiposDias) {
        this.diasCalendario = OperacionesCalendario.GenerarDiasCalendario(DateTime.Now.Year);
        vacaciones.ToList().ForEach(x => {
            var dia = this.diasCalendario.FirstOrDefault(y => x.FechaCalendario.Date == y.Date);
            if (dia != null) {
                var tipoDia = tiposDias.First(y => y.Id == x.TipoDiaCalendario);
                dia.ColorSeleccion = tipoDia.ColorRepresentacion;
                dia.TipoDia = tipoDia.Descripcion;
            }
        });
        StateHasChanged();
    }



    #region Event Listeners

    /// <summary>
    /// Dado un mes selecciona todos los dias(Laborables) de ese mes y los marca como el estado de dia seleccionado.
    /// </summary>
    /// <param name="dias"></param>
    /// <returns></returns>
    public void SelectAllMonthButtonListener(DatosDias dias) {
        var DiasSeleccionables = dias.Where(X => X.Date.DayOfWeek != DayOfWeek.Sunday && X.Date.DayOfWeek != DayOfWeek.Saturday);
        SelectMultipleDays(new DatosDias(DiasSeleccionables));
    }


    /// <summary>
    /// Gestión de selección de dias en función del valor de la multiseleccion
    /// </summary>
    /// <param name="dia"></param>
    public void DaySelectorEventListener(DatoDia dia) {
        if (this.DayMultiseletionMode) MultiSelectionDayClickListener(dia);
        else SingleSelectionDay(dia);
    }

    /// <summary>
    /// Gestión de la multiseleccion de los dias
    /// </summary>
    /// <param name="dia"></param>
    /// <returns></returns>
    public void MultiSelectionDayClickListener(DatoDia dia) {
        //Establece el primer dia para la multiseleccion si no ha comenzado ya
        if (OperacionesCalendario.NingunDiaFiltro(this.diasCalendario, new Func<DatoDia, bool>(dia => dia.ColorSeleccion == PublicVariables.colorInicioMultiseleccion))) {
            dia.ColorSeleccion = PublicVariables.colorInicioMultiseleccion;
            return;
        }

        //Si ya existe un primer dia de multiseleecion, este click marca el final de la multiseleccion, por tanto debemos marcar los dias como seleccionados
        if (OperacionesCalendario.NumeroDiasFiltro(this.diasCalendario, new Func<DatoDia, bool>(dia => dia.ColorSeleccion == PublicVariables.colorInicioMultiseleccion)) > 0) {
            //this.DayMultiseletionMode = false;

            //Devuelve el resultado de hacer multiseleccion en los dias
            SelectMultipleDays(
                new DatosDias(OperacionesCalendario.FiltroDia(this.diasCalendario, new(dia => dia.ColorSeleccion == PublicVariables.colorInicioMultiseleccion || dia.ColorSeleccion == PublicVariables.colorOver))
            ));
        }
    }

    /// <summary>
    /// Este metodo colorea el dia en el calendario si no estaba seleccionado al hacer hover, si estaba seleccionado lo deselecciona.
    /// Hay que tener en cuenta que no se podrá colorear el boton de inicio de la multiseleccion y que el modo de multiseleccion deberá estar activo
    /// </summary>
    /// <param name="dia"></param>
    public void HoverButtonListener(DatoDia dia) {
        if (//Debe estar el modo multiseleccion
            this.DayMultiseletionMode &&
            //Debe aver un boton en modo multiseleccion
            !OperacionesCalendario.NingunDiaFiltro(this.diasCalendario, new(dia => dia.ColorSeleccion == PublicVariables.colorInicioMultiseleccion))
            //Este boton no puede ser el de inicio de la multiseleccion
            && dia.ColorSeleccion != PublicVariables.colorInicioMultiseleccion)

            //Incomodo pero podría ponerse, sería para poder hacer hover y quitarlo
            //dia.ColorSeleccion = dia.ColorSeleccion == colorOver ? colorInicial : colorOver;            
            dia.ColorSeleccion = PublicVariables.colorOver;
    }

    /// <summary>
    /// Boton de guardar datos del calendario 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public async Task SaveCalendarButtonListener() {
        var usuarioActivo = this._authenticationStateProvider.GetCurrentUser(_api);
        //Obtenemos dias desde la aplicacion
        var vacacionesEnAplicacion = await _api.GetUsuarioCalendarioVacacionesAsync(usuarioActivo.IdTecnico);

        //Borramos primero los dias que antes eran de vacaciones y que ahora son laborables
        //Es decir que se borran las vacaciones estén almacenadas con la misma fecha y que ahora sean laborables
        var diasGuardadosYAhoraLaborables = this.diasCalendario.Where(x => vacacionesEnAplicacion.Any(X => X.FechaCalendario == x.Date) && x.TipoDia == "Laborable");
        await BorrarDatosCalendario(diasGuardadosYAhoraLaborables, usuarioActivo.IdTecnico);

        //Actualizamos los dias que han cambiado su estado
        await ActualizarDiasQueCambiaronSuEstado(vacacionesEnAplicacion,usuarioActivo.IdTecnico);

       //Añadimos por ultimo nuevos dias
        IEnumerable<DatoDia> nuevosDias = this.diasCalendario.Where(X => X.TipoDia != "Laborable" && 
                                                                         X.TipoDia != "Disabled" && 
                                                                         X.TipoDia != "Festividad" &&  
                                                                         !vacacionesEnAplicacion.Any(Y => Y.FechaCalendario.Date == X.Date));
        await AddNuevosDias(nuevosDias,usuarioActivo.IdTecnico);

        await OnAfterRenderAsync(true);
    }

    /// <summary>
    /// Añadimos los nuevos dias de vacaciones
    /// </summary>
    /// <param name="nuevosDias">Nuevos dias a añadir</param>
    /// <param name="idTecnico">Id del usuario del que se añadirá las vacaciones</param>
    /// <returns></returns>
    public async Task AddNuevosDias(IEnumerable<DatoDia> nuevosDias,int idTecnico) {
        var tiposDias = await _api.GetAllTipoDiaCalendarioAsync();
        foreach (var dia in nuevosDias) {
            await _api.CreateCalendarioVacacionesAsync(new CreateCalendarioVacacionesCommand() { 
                FechaCalendario = dia.Date, 
                IdTecnico = idTecnico, 
                TipoDiaCalendario = tiposDias.First(x => x.ColorRepresentacion == dia.ColorSeleccion).Id
            });
        }
    }

    /// <summary>
    /// Actualizar los tipos de dias con un nuevo estado
    /// </summary>
    /// <param name="vacacionesEnAplicacion">Vacaciones almacenadas en la aplicacion</param>
    /// <param name="idUsuario">id del usuario</param>
    /// <returns></returns>
    public async Task ActualizarDiasQueCambiaronSuEstado(IEnumerable<CalendarioVacacionesResponse> vacacionesEnAplicacion,int idUsuario) {
        //Dias y Tipos de dia almacenados en la aplicacion
        var tiposDias = await _api.GetAllTipoDiaCalendarioAsync();

        //Obtenemos los dias que han cambiado su estado
        var diasConEstadoCambiado = this.diasCalendario.Where(X => X.TipoDia != "Laborable" &&
                                                                   X.TipoDia != "Disabled" &&
                                                                   X.TipoDia != "Festividad" &&
                                                                   vacacionesEnAplicacion.Any(Y => Y.FechaCalendario.Date == X.Date) &&
                                                                   tiposDias.First(Z => Z.Id == vacacionesEnAplicacion.First(Y => Y.FechaCalendario.Date ==                                                        X.Date).TipoDiaCalendario).Descripcion != X.TipoDia);
        if (diasConEstadoCambiado.Any())
        foreach (var item in diasConEstadoCambiado) {
            await _api.ReplaceCalendarioVacacionesAsync(new ReplaceCalendarioVacacionesCommand() {
                FechaCalendarioNew = item.Date,
                FechaCalendarioOld = item.Date,
                IdTecnico = idUsuario,
                TipoDiaCalendarioNew = tiposDias.First(X => X.Descripcion == item.TipoDia).Id,
                TipoDiaCalendarioOld = vacacionesEnAplicacion.First(x => x.FechaCalendario == item.Date).TipoDiaCalendario
            }); ;
        }
    }


    /// <summary>
    /// Borrar datos de la aplicacion
    /// </summary>
    /// <param name="diasBorrar">Dias para borrar en la aplicacion</param>
    /// <param name="IdTecnicoUsuario">Id del usuario dle que se borran las vacaciones</param>
    /// <returns></returns>
    public async Task BorrarDatosCalendario(IEnumerable<DatoDia> diasBorrar,int IdTecnicoUsuario) {
        if (diasBorrar.Any())
            foreach (var diaBorrar in diasBorrar) {

                await _api.DeleteCalendarioVacacionesAsync(new DeleteCalendarioVacacionesCommand() {
                    Fecha = diaBorrar.Date,
                    UsuarioID = IdTecnicoUsuario
                });
            }
    }

    //todo
    /// <summary>
    /// Boton de salir sin guardar, Recarga el estado del calendario
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public async Task CancelarCambiosButtonListener() {
        await OnAfterRenderAsync(true);
    }

    #endregion
}







