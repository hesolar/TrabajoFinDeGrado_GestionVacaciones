namespace Application.Handlers.CommandHandlers;


public class CreateProyectoHandler : IRequestHandler<CreateProyectoCommand, bool> {
    private readonly IProyectoRepository _proyectoRepo;
    public CreateProyectoHandler(IProyectoRepository employeeRepository) {
        _proyectoRepo = employeeRepository;
    }
    public async Task<bool> Handle(CreateProyectoCommand request, CancellationToken cancellationToken) {
        var employeeEntitiy = MapperBase<ProyectoMappingProfile, Core.Entities.Proyecto>.MappEntity(request);
        if (employeeEntitiy is null) throw new ApplicationException("Issue with mapper");
        return await _proyectoRepo.AddAsync(employeeEntitiy);
    }
}