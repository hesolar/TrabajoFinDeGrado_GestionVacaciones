using WebAPI.Clases.XmlParser;

namespace WebAPI.Clases.DatosServicio {
    public class DataAcessFromDB : DataAccess {
        public DataAcessFromDB(string ConnectionString) : base(ConnectionString) {
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
}
