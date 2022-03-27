namespace Application.Mapper;


public class UsuarioMappingProfile : Profile {
    public UsuarioMappingProfile() {
        CreateMap<Core.Entities.Usuario, UsuarioResponse>().ReverseMap();
        CreateMap<Core.Entities.Usuario, CreateUsuarioCommand>().ReverseMap();
    }
}