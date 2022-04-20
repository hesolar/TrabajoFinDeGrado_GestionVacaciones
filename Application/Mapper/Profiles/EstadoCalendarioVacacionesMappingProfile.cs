namespace Application.Mapper;
public class EstadoCalendarioVacacionesMappingProfile: Profile {

    public EstadoCalendarioVacacionesMappingProfile() {
        CreateMap<Core.Entities.EstadoCalendarioVacaciones, EstadoCalendarioVacacionesResponse>().ReverseMap();
    }
}
