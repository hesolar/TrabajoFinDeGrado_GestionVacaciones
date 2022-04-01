namespace WebAPI.Clases.HolidayContainer; 
public class HolidayDataContainer_Title_Estado_DateI_DateF : IHolidayDataContainer {


    public String TitlePersona { get; set; }
    public String EstadoDia { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }



    public HolidayDataContainer_Title_Estado_DateI_DateF(Tuple<String, String, DateTime, DateTime> dato) {
        this.TitlePersona = dato.Item1;
        this.EstadoDia = dato.Item2;
        this.FechaInicio = dato.Item3;
        this.FechaFin = dato.Item4;
    }

    public HolidayDataContainer_Title_Estado_DateI_DateF() {

    }


    public object ContainObject() 
        => Tuple.Create(this.TitlePersona, this.EstadoDia, this.FechaInicio, this.FechaFin);

    public IEnumerable<IHolidayDataContainer> GetContainers(List<Tuple<string, string, DateTime, DateTime>> datos) {
        List<HolidayDataContainer_Title_Estado_DateI_DateF> containers = new();
        datos.ForEach(dato => containers.Add(new HolidayDataContainer_Title_Estado_DateI_DateF(dato)));
        return containers;

    }
}

