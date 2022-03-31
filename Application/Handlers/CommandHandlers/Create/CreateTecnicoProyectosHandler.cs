namespace Application.Handlers.CommandHandlers;
public class CreateTecnicoProyectosHandler : IRequestHandler<CreateTecnicoProyectosCommand, bool> {
    private readonly ITecnicoProyectosRepository _repo;
    public CreateTecnicoProyectosHandler(ITecnicoProyectosRepository TecnicoProyectosRepository) {
        _repo = TecnicoProyectosRepository;
    }
    public async Task<bool> Handle(CreateTecnicoProyectosCommand request, CancellationToken cancellationToken) {
        var entity = MapperBase<TecnicoProyectosMappingProfile, Core.Entities.TecnicoProyectos>.MappEntity(request);
        if (entity is null) throw new ApplicationException("Issue with mapper");
        return await _repo.AddAsync(entity);
    }
}
