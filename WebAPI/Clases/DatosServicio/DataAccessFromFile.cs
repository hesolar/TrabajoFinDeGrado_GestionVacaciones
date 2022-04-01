using System.Xml;
using System.Xml.Serialization;
using WebAPI.Clases.XmlParser;

namespace WebAPI.Clases.DatosServicio;
public class DataAccessFromFile : DataAccess {
    public DataAccessFromFile(string ConnectionString) : base(ConnectionString) {
    }

    public override feed GetAllData() {
        XmlSerializer ser = new(typeof(feed));
        feed feedTotal;
        using (XmlReader reader = XmlReader.Create(base.connectionString)) {
            feedTotal = (feed)ser.Deserialize(reader);
        }
        return feedTotal;
    }

    public override void GetField() {
        throw new NotImplementedException();
    }

    public override void GetStuff() {
        throw new NotImplementedException();
    }
}


