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

        //public string ObtenerColor(int numero) {

        //    if (TotalUsuarios < 5) {
        //        if (numero == 0) return colores[0];
        //        if (numero == 1) return colores[1];
        //        if (numero == 2) return colores[2];
        //        if (numero == 3) return colores[3];
        //        return colores.Last();
        //    }
        //    else { 
            
            
            
        //    }
        
        //}

    
    }
}
