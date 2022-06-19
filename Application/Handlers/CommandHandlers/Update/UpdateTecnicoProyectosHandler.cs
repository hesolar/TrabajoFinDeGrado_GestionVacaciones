namespace Application.Handlers.CommandHandlers;

public class UpdateTecncioProyectosHandler : IRequestHandler<UpdateTecnicoProyectosCommand, bool> {
    private readonly ITecnicoProyectosRepository _repostory;

    public UpdateTecncioProyectosHandler(ITecnicoProyectosRepository TecnicoProyectoRepository) {
        _repostory = TecnicoProyectoRepository;
    }

    public async Task<bool> Handle(UpdateTecnicoProyectosCommand request, CancellationToken cancellationToken) {

        Core.Entities.TecnicoProyectos newEntity= MapperBase<TecnicoProyectosMappingProfile, Core.Entities.TecnicoProyectos>.MappEntity(request);
        Core.Entities.TecnicoProyectos oldEntity = await _repostory.GetByIdAsync(newEntity.IdTecnico);
        return await _repostory.ReplaceAsync(oldEntity, newEntity);

        
    }


}
