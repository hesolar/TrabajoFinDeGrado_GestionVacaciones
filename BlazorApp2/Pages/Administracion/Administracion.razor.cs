namespace BlazorApp2.Pages.Administracion {
    public class AdministracionVacacionesBase: ComponentBase {

        protected IEnumerable<UsuarioResponse> Usuarios;
        protected IEnumerable<RolesResponse> Roles;
        protected IEnumerable<TipoDiaCalendarioResponse> TiposDias;
        protected IEnumerable<EstadoCalendarioVacacionesResponse> EstadosDias;
        protected IEnumerable<CalendarioVacacionesResponse> TotalPeticiones;

        [Inject]
        public API _api { get; set; }

        protected ErrorBoundary ErrorBoundaryInsercionesNomodificaciones;
        public void RecoverAppState() => ErrorBoundaryInsercionesNomodificaciones.Recover();

        public IEnumerable<UsuarioResponse> UsuariosAplicacion { get; set; }
        public RadzenDataGrid<CalendarioVacacionesResponse> PeticionesGrid { get; set; }

        protected CalendarioVacacionesResponse calendarioToModify;


        public bool IsLoading = false;
        public bool insercion = false;

        protected override async Task OnInitializedAsync() {
            await LoadData();

        }


        protected  async Task LoadData() {
            IsLoading = true;
                this.Roles = await _api.GetAllRolesAsync();
                this.TiposDias = await _api.GetAllTipoDiaCalendarioAsync();
                this.EstadosDias = await _api.GetAllEstadoCalendarioVacacionesAsync();
                this.Usuarios = await _api.GetAllUsuariosAsync();
                this.TotalPeticiones = await _api.GetAllCalendarioVacacionesAsync();
                StateHasChanged();
            IsLoading = false;
        }




        protected async Task OnUpdateRow(CalendarioVacacionesResponse calendario) {
            if (calendario == calendarioToModify) calendarioToModify = null;
            
            UpdateCalendarioVacacionesCommand u = MapFrom<CalendarioVacacionesResponse, UpdateCalendarioVacacionesCommand>.Map(calendario);
            await _api.UpdateCalendarioVacacionesAsync(u);

            await LoadData();

        }

        public async Task SaveRow(CalendarioVacacionesResponse calendario) {
            if (insercion && validarCalendario(calendario)) {
                CreateCalendarioVacacionesCommand c = MapFrom<CalendarioVacacionesResponse, CreateCalendarioVacacionesCommand>.Map(calendario);
                await _api.CreateCalendarioVacacionesAsync(c);
                await LoadData();
                insercion = false;
            }
            else {
                UpdateCalendarioVacacionesCommand c = MapFrom<CalendarioVacacionesResponse, UpdateCalendarioVacacionesCommand>.Map(calendario);
                await _api.UpdateCalendarioVacacionesAsync(c);
                await PeticionesGrid.UpdateRow(calendario);
            
            }
        }

        public bool validarCalendario(CalendarioVacacionesResponse calendario) {
            return this.Usuarios.Select(X => X.IdTecnico).Contains(calendario.IdTecnico)
                   && this.EstadosDias.Select(X => X.Id).Contains(calendario.Estado)
                   && this.TiposDias.Select(X => X.Id).Contains(calendario.TipoDiaCalendario);
        }

        public void CancelEdit(CalendarioVacacionesResponse calendario) {
            if (calendario == calendarioToModify) calendarioToModify = null;
            PeticionesGrid.CancelEditRow(calendario);
        }

        public async Task DeleteRow(CalendarioVacacionesResponse calendario) {
            if (calendario == calendarioToModify) calendarioToModify = null;


            
                DeleteCalendarioVacacionesCommand d = MapFrom<CalendarioVacacionesResponse, DeleteCalendarioVacacionesCommand>.Map(calendario);
                await _api.DeleteCalendarioVacacionesAsync(d);

                await LoadData();
                StateHasChanged();
            
            //else {
            //    P.CancelEditRow(calendario);
            //}

        }

        protected async Task InsertRow() {
            insercion = true;
            this.calendarioToModify = new ();
            await PeticionesGrid.InsertRow(calendarioToModify);
        }

        protected async Task EditRow(CalendarioVacacionesResponse rol) {
            this.calendarioToModify = rol;
            await PeticionesGrid.EditRow(rol);
        }
        protected async Task OnCreateRow(CalendarioVacacionesResponse calendario) {
            CreateCalendarioVacacionesCommand c = MapFrom<CalendarioVacacionesResponse, CreateCalendarioVacacionesCommand>.Map(calendario);
            await _api.CreateCalendarioVacacionesAsync(c);
        }

    }
}
