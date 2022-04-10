namespace BlazorApp2.Shared; 
public class ExcepcionDeAplicacion : Exception{
    public string _message { get; set; }
    public ExcepcionDeAplicacion(string message) {
        _message = message;
    }

}
