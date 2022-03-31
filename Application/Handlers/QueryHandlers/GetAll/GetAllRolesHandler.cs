namespace Application.Handlers.QueryHandlers;

public class GetAllRolessHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<RolesResponse>> {
    private readonly IRolesRepository _repo;

    public GetAllRolessHandler(IRolesRepository repo) {
        _repo = repo;
    }
    public async Task<IEnumerable<RolesResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken) {
        IReadOnlyList<Core.Entities.Roles> Roless = await _repo.GetAllAsync();
        return MapperBase<RolesMappingProfile, RolesResponse>.MappIEnumerable(Roless);
    }
}
