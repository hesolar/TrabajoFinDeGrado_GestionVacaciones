namespace Application.Handlers.CommandHandlers;

public class UpdateProyectoHandler : IRequestHandler<UpdateProyectoCommand, bool> {
    private readonly IProyectoRepository _repostory;

    public UpdateProyectoHandler(IProyectoRepository ProyectoRepository) {
        _repostory = ProyectoRepository;
    }

    public async Task<bool> Handle(UpdateProyectoCommand request, CancellationToken cancellationToken) {
        Core.Entities.Proyecto newValue = MapperBase<ProyectoMappingProfile, Core.Entities.Proyecto>.MappEntity(request);
        Core.Entities.Proyecto oldValue = await _repostory.GetByIdAsync(newValue.IdProyecto);
        return await _repostory.UpdateAsync(oldValue,newValue);
    }
}

