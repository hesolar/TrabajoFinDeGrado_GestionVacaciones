namespace BlazorApp2.Pages.GestionEquipo {
    public class GestionEquipoBase : ComponentBase {

        [Inject] API _api { get; set; }
        [Inject]AuthenticationStateProvider _authenticationStateProvider { get; set; }


        protected RadzenCard TarjetaComboVacacionesUsuario = new();
        protected RadzenCard TarjetaCalendarioEquipo = new();

        public List<ProyectoResponse> proyectosUsuario;
        protected RadzenDropDownDataGrid<String> dropdownProyectos;
        protected ProyectoResponse proyectoSeleccionado;
        protected int TotalUsuariosProyecto = 0;
        protected Dictionary<CalendarioVacacionesResponse, int> totalVacaciones = new();

        protected override async Task OnInitializedAsync() {

            UsuarioResponse currentAppUser = _authenticationStateProvider.GetCurrentUser(_api);
            IEnumerable<int> IdProyectos = await _api.GetProyectosUsuarioAsync(currentAppUser.IdTecnico);
            proyectosUsuario = new();
            foreach (var idProyecto in IdProyectos) {
                ProyectoResponse s = await _api.GetProyectoByIdAsync(idProyecto);
                proyectosUsuario.Add(s);
            }
        }
        protected bool actualizarProyecto;
        protected async Task OnChange(Object value) {
            this.proyectoSeleccionado = this.proyectosUsuario.First(X => X.Nombre == this.dropdownProyectos.SelectedItem.ToString());
            actualizarProyecto = false;
            this.TarjetaCalendarioEquipo.Visible = false;
            StateHasChanged();
            actualizarProyecto = true;
            var totalUsuarios = await _api.GetUsuariosProyectoAsync(this.proyectoSeleccionado.IdProyecto);
            this.TotalUsuariosProyecto = totalUsuarios.Count();

            this.totalVacaciones = new();
            Action<Dictionary<CalendarioVacacionesResponse, int>, CalendarioVacacionesResponse> AddDiaCalendario = (totalDias, nuevoDia) => {

                var dia = totalDias.FirstOrDefault(x => x.Key.FechaCalendario == nuevoDia.FechaCalendario);
                if (dia.Key != null) {
                    totalDias[dia.Key] += 1;
                }

                else {

                    totalDias.Add(nuevoDia, 1);
                }

            };
            foreach (var usuario in totalUsuarios) {
                IEnumerable<CalendarioVacacionesResponse> resultados = await _api.GetUsuarioCalendarioVacacionesAsync(usuario);

                resultados.ToList().ForEach(X => AddDiaCalendario(this.totalVacaciones, X));
            }

            this.TarjetaCalendarioEquipo.Visible = true;


        }
    }
}
