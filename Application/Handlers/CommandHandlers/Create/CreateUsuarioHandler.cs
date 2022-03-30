namespace Application.Handlers.CommandHandlers;
public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, bool> {
    private readonly IUsuarioRepository _userRepo;
    public CreateUsuarioHandler(IUsuarioRepository employeeRepository) {
        _userRepo = employeeRepository;
    }
    public async Task<bool> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken) {
        var employeeEntitiy = MapperBase<UsuarioMappingProfile, Core.Entities.Usuario>.MappEntity(request);
        if (employeeEntitiy is null) throw new ApplicationException("Issue with mapper");
        return await _userRepo.AddAsync(employeeEntitiy);
    }
}
