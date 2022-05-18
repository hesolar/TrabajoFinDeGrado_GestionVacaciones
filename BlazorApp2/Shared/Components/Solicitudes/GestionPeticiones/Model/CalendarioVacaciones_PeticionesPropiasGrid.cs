﻿namespace BlazorApp2.Pages.Peticiones.Solicitudes;

public static class MetodosExtension_GestionPeticiones {
    public static CalendarioVacaciones_GestionPeticionesGrid Convertir(this CalendarioVacacionesResponse c,
                                                         IEnumerable<EstadoCalendarioVacacionesResponse> estados, 
                                                         IEnumerable<TipoDiaCalendarioResponse> tipos,
                                                         UsuarioResponse usuario) {


        return new CalendarioVacaciones_GestionPeticionesGrid() {
            Nombre = usuario.Nombre,
            Apellido1 = usuario.Apellido1,
            Apellido2 = usuario.Apellido2,
            FechaCalendario = c.FechaCalendario.Date,
            EmailCorporativo = usuario.EmailCorporativo,
            TipoDiaCalendario = tipos.First(x => x.Id == c.TipoDiaCalendario).Descripcion,
            Estado = estados.First(x => x.Id == c.Estado).Descripcion
        };
    }

    public static IEnumerable<CalendarioVacaciones_GestionPeticionesGrid> ConvertirListado(this IEnumerable<CalendarioVacacionesResponse> calendarios, 
                                                                                                IEnumerable<UsuarioResponse> usuarios,
                                                                                                IEnumerable<EstadoCalendarioVacacionesResponse> estados, 
                                                                                                IEnumerable<TipoDiaCalendarioResponse> tipos) {
        List<CalendarioVacaciones_GestionPeticionesGrid> resultados = new();
        int index = 0;
        var usuariosLista = usuarios.ToList();
        foreach (var item in calendarios) {
            var usuario = usuariosLista[index];
            resultados.Add(item.Convertir(estados, tipos, usuario));
            index += 1;
        }
        return resultados;
    }

}
