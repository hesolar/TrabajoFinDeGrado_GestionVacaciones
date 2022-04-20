namespace Application.Mapper;
public class TipoDiaCalendarioMappingProfile: Profile {

    public TipoDiaCalendarioMappingProfile() {
        CreateMap<Core.Entities.TipoDiaCalendario, TipoDiaCalendarioResponse>().ReverseMap();
        CreateMap<Core.Entities.TipoDiaCalendario, CreateTipoDiaCalendarioCommand>().ReverseMap();
        CreateMap<Core.Entities.TipoDiaCalendario, DeleteTipoDiaCalendarioCommand>().ReverseMap();
        CreateMap<Core.Entities.TipoDiaCalendario, UpdateTipoDiaCalendarioCommand>().ReverseMap();
    }
}
