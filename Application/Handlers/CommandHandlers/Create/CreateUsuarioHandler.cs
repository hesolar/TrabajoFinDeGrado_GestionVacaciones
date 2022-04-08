﻿namespace Application.Handlers.CommandHandlers;
public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, bool> {
    private readonly IUsuarioRepository _usuarioRepo;
    private readonly IUsuarioProyectoRepository _usuarioProyectoRepo;

    public CreateUsuarioHandler(IUsuarioRepository employeeRepository,IUsuarioProyectoRepository usuarioProyectoRepo) {
        _usuarioRepo = employeeRepository;
        _usuarioProyectoRepo = usuarioProyectoRepo;
    }
    public async Task<bool> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken) {
        //añade usuario
        var employeeEntitiy = MapperBase<UsuarioMappingProfile, Core.Entities.Usuario>.MappEntity(request);
        if (employeeEntitiy is null) throw new ApplicationException("Issue with mapper");
        var result=  _usuarioRepo.AddAsync(employeeEntitiy);
        //añade proyectos de usuario
        bool resultadoAñadir =  await AddProyectosUsuario(request.Proyectos, employeeEntitiy.IdTecnico);
        //resultado de añadir usuario y sus proyectos
        return result.Result && resultadoAñadir;
    }
    /// <summary>
    /// Añade proyectos de un usuario
    /// </summary>
    /// <param name="proyectos"></param>
    /// <param name="idUsuario"></param>
    /// <returns></returns>
    public async Task<bool> AddProyectosUsuario(IEnumerable<int> proyectos, int idUsuario) {
        bool result = true;
        proyectos.ToList().ForEach(proyecto => {
            result = result &&  _usuarioProyectoRepo.NuevoProyectoUsuario(idUsuario, proyecto).Result;
        });
        return result;
    }

}
