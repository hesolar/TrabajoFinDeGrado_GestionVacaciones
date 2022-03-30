namespace Application.Mapper.MappingProfiles;

public class UsuarioMappingProfile : Profile {
    public UsuarioMappingProfile() {
        CreateMap<Core.Entities.Usuario, UsuarioResponse>().ReverseMap();
        CreateMap<Core.Entities.Usuario, CreateUsuarioCommand>().ReverseMap();
        CreateMap<Core.Entities.Usuario, DeleteUsuarioCommand>().ReverseMap();
        CreateMap<Core.Entities.Usuario, UpdateUsuarioCommand>().ReverseMap();
    }
} 