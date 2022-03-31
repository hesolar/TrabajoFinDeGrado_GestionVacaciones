namespace Application.Mapper;
public class CalendarioVacacionesMappingProfile: Profile {

    public CalendarioVacacionesMappingProfile() {
        CreateMap<Core.Entities.CalendarioVacaciones, CalendarioVacacionesResponse>().ReverseMap();
        CreateMap<Core.Entities.CalendarioVacaciones, CreateCalendarioVacacionesCommand>().ReverseMap();
        CreateMap<Core.Entities.CalendarioVacaciones, DeleteCalendarioVacacionesCommand>().ReverseMap();
        CreateMap<Core.Entities.CalendarioVacaciones, UpdateCalendarioVacacionesCommand>().ReverseMap();
    }
}
