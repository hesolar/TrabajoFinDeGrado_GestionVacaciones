namespace Application.Mapper.MappingProfiles;

public class UsuarioProyectoMappingProfile : Profile {
    public UsuarioProyectoMappingProfile() {
        CreateMap<Core.Entities.UsuarioProyecto, UsuarioProyectoResponse>().ReverseMap();
        CreateMap<Core.Entities.UsuarioProyecto, CreateUsuarioProyectoCommand>().ReverseMap();
        CreateMap<Core.Entities.UsuarioProyecto, DeleteUsuarioProyectoCommand>().ReverseMap();
    }
} 