namespace Application.Handlers.QueryHandlers;


public class GetSubordinadosQueryHandler : IRequestHandler<GetSubordinadosQuery, IEnumerable<CalendarioVacacionesResponse>> {
    private readonly IUsuarioRepository _usuariosRepository;
    private readonly ICalendarioVacacionesRepository _calendarioVacacionesrepository;
    private readonly IUsuarioProyectoRepository _usuarioProyectoRepository;

    public GetSubordinadosQueryHandler(IUsuarioRepository usuarioRepository,ICalendarioVacacionesRepository calendarioVacacionesRepository, IUsuarioProyectoRepository usuarioProyectoRepository) {
        _usuariosRepository = usuarioRepository;
        _calendarioVacacionesrepository = calendarioVacacionesRepository;
        _usuarioProyectoRepository = usuarioProyectoRepository;
    }

    async Task<IEnumerable<CalendarioVacacionesResponse>> IRequestHandler<GetSubordinadosQuery, IEnumerable<CalendarioVacacionesResponse>>.Handle(GetSubordinadosQuery request, CancellationToken cancellationToken) {
        int id = request.IdUsuario;

        var proyectos = await _usuarioProyectoRepository.GetProyectosUsuario(request.IdUsuario);
        HashSet<int> usuarios = new();
        foreach (var proyecto in proyectos) {
            var usuariosEncontrados = await _usuarioProyectoRepository.GetUsuarioProyectos(proyecto);
            usuariosEncontrados.ToList().ForEach(X=> usuarios.Add(X));
        }
        List<Core.Entities.Usuario> usuariosFinales = new ();    
        
        foreach(var usuario in usuarios) {

            var usuarioEncontrado =  await _usuariosRepository.GetByIdAsync(usuario);
            if (usuarioEncontrado.WebRol < request.WebRol) usuariosFinales.Add(usuarioEncontrado);
        }
        List<Core.Entities.CalendarioVacaciones> vacaciones = new();
        foreach (var uf in usuariosFinales) {
            var dias = await _calendarioVacacionesrepository.GetDiaUsuario(uf.IdTecnico);
            dias.ToList().ForEach(X=> vacaciones.Add(X));
        }
        return MapperBase<CalendarioVacacionesMappingProfile, CalendarioVacacionesResponse>.MappIEnumerable(vacaciones);
    }
}

