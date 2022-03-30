namespace Application.Mapper;
public class TecnicoProyectosMappingProfile : Profile {
    public TecnicoProyectosMappingProfile() {
        CreateMap<Core.Entities.TecnicoProyectos, TecnicoProyectosResponse>().ReverseMap();
        CreateMap<Core.Entities.TecnicoProyectos, CreateTecnicoProyectosCommand>().ReverseMap();
        //CreateMap<Core.Entities.TecnicoProyectos, DeleteTecnicoProyectosCommand>().ReverseMap();
        //CreateMap<Core.Entities.TecnicoProyectos, UpdateTecnicoProyectosCommand>().ReverseMap();
    }
}
