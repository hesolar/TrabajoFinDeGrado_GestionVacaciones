namespace Application.Handlers.CommandHandlers;

public class UpdateTecncioProyectosHandler : IRequestHandler<UpdateTecnicoProyectosCommand, bool> {
    private readonly ITecnicoProyectosRepository _repostory;

    public UpdateTecncioProyectosHandler(ITecnicoProyectosRepository TecnicoProyectoRepository) {
        _repostory = TecnicoProyectoRepository;
    }

    public async Task<bool> Handle(UpdateTecnicoProyectosCommand request, CancellationToken cancellationToken) {

        Core.Entities.TecnicoProyectos entity= MapperBase<TecnicoProyectosMappingProfile, Core.Entities.TecnicoProyectos>.MappEntity(request);
        return await _repostory.UpdateAsync(entity);

        
    }


}
