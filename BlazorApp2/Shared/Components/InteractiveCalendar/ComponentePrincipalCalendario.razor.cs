namespace BlazorApp2.Shared.Components.InteractiveCalendar; 
public class ComponentePrincipalCalendarioBase: ComponentBase {
    [Inject] protected API _api { get; set; }
    [Parameter] public bool BotonesVisibles { get; set; }

    protected IEnumerable<TipoDiaCalendarioResponse> data { get; set; } = new List<TipoDiaCalendarioResponse>();
    protected RadzenRadioButtonList<string> radiobutton;
    protected string valor;
    protected bool Multiseleccion { get; set; }
    protected InteractiveCalendar calendario = new();

    protected override async Task OnParametersSetAsync() {
        data = await _api.GetAllTipoDiaCalendarioAsync();
        this.valor = data.First().Descripcion;
        this.radiobutton.Value = valor;
        StateHasChanged();
    }
    protected void NotifyChange(bool change) {
        BotonesVisibles = !change;
    }

}
