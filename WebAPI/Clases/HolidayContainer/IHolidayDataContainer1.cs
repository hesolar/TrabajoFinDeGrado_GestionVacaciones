namespace WebAPI.Clases.HolidayContainer;
public interface IHolidayDataContainer {

    public String TitlePersona { get; set; }
    public String EstadoDia { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public IEnumerable<IHolidayDataContainer> GetContainers(List<Tuple<string, string, DateTime, DateTime>> datos);
    public Object ContainObject();


}

