using WebAPI.Clases.DatosServicio;
using WebAPI.Clases.XmlParser;

namespace WebAPI.NuevasClases.DatosServicio;
public class DataAccessFromService : DataAccess {
    public DataAccessFromService(string ConnectionString) : base(ConnectionString) {
    }

    public override feed GetAllData() {
        throw new NotImplementedException();
    }

    public override void GetField() {
        throw new NotImplementedException();
    }

    public override void GetStuff() {
        throw new NotImplementedException();
    }
}


