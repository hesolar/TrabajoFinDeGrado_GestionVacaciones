using WebAPI.Clases.XmlParser;

namespace WebAPI.Clases.DatosServicio;
public abstract class DataAccess {
    protected string connectionString;



    private void SetConnectionString(string value) {
        connectionString = value;
    }

    public DataAccess(string ConnectionString) {
        this.SetConnectionString(ConnectionString);
    }
    public abstract feed GetAllData();
    public abstract void GetField();
    public abstract void GetStuff();


}


