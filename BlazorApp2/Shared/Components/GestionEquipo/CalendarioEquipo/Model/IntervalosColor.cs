namespace BlazorApp2.Shared.Components.GestionEquipo.CalendarioEquipo.Model {
    public class IntervalosColor {

        public readonly List<String> colores;


        public IntervalosColor(int totalUsuarios) {
            colores = new() {
                "73E600",
                "BFE600",
                "E6E600",
                "FFAA00",
                "FF2A00" };
            this.TotalUsuarios = totalUsuarios;

        }
        public int TotalUsuarios;
   
    }
}
