namespace Application.Handlers.CommandHandlers;

public class UpdateProyectoHandler : IRequestHandler<UpdateProyectoCommand, bool> {
    private readonly IProyectoRepository _repostory;

    public UpdateProyectoHandler(IProyectoRepository ProyectoRepository) {
        _repostory = ProyectoRepository;
    }

    public async Task<bool> Handle(UpdateProyectoCommand request, CancellationToken cancellationToken) {
        Core.Entities.Proyecto entity = MapperBase<ProyectoMappingProfile, Core.Entities.Proyecto>.MappEntity(request);
        return await _repostory.UpdateAsync(entity);
    }
}

