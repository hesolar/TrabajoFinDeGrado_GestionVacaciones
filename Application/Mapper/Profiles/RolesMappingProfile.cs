namespace Application.Mapper;
public class RolesMappingProfile : Profile {
    public RolesMappingProfile() {

        CreateMap<Core.Entities.Roles, RolesResponse>().ReverseMap();
        CreateMap<Core.Entities.Roles, CreateRolesCommand>().ReverseMap();
        //CreateMap<Core.Entities.Roles, DeleteRolesCommand>().ReverseMap();
        CreateMap<Core.Entities.Roles, UpdateRolesCommand>().ReverseMap();
    }
}
