namespace Application.Mapper {
    public class ProyectoMappingProfile : Profile{

        public ProyectoMappingProfile() {
            CreateMap<Core.Entities.Proyecto,ProyectoResponse>().ReverseMap();
            CreateMap<Core.Entities.Proyecto, CreateProyectoCommand>().ReverseMap();
            //CreateMap<Core.Entities.Proyecto, DeleteProyectoCommand>().ReverseMap();
            //CreateMap<Core.Entities.Proyecto, UpdateProyectoCommand>().ReverseMap();
        }
    }
}