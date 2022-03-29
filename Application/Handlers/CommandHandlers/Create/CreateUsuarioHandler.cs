namespace Application.Handlers.CommandHandlers;


public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioCommand, UsuarioResponse> {

    private readonly IUsuarioRepository _userRepo;
    public CreateUsuarioHandler(IUsuarioRepository employeeRepository) {
        _userRepo = employeeRepository;
    }
    public async Task<UsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken) {
        var employeeEntitiy = UsuarioMapper.Mapper.Map<Core.Entities.Usuario>(request);
        if (employeeEntitiy is null) {
            throw new ApplicationException("Issue with mapper");
        }
        var newEmployee = await _userRepo.AddAsync(employeeEntitiy);
        var employeeResponse = UsuarioMapper.Mapper.Map<UsuarioResponse>(newEmployee);
        return employeeResponse;
    }
}
