
namespace Application.Operations.Commands;

public class UpdateTipoDiaCalendarioCommand : IRequest<bool> {
    public int Id { get; set; }
    public String Descripcion { get; set; }
    public String ColorRepresentacion { get; set; }
    public int Festivo { get; set; }



}