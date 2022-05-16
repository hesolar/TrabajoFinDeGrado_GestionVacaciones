namespace BlazorApp2.Pages.Gestion.CalendarioEquipo;

public static class OperacionesCalendario {

    /// <summary>
    /// Dado un calendario genera los distintos dias .
    /// </summary>
    /// <param name="calendarioAnual"></param>
    /// <returns></returns>
    public static DatosDias GenerarDiasCalendario(int year) {
        DateTime FechaInicio = new(year, 1, 1);
        DateTime FechaMaxima = new(year + 1, 1, 1);

        List<DatoDiaCalendarioEquipo> resultados = new();
        while (FechaInicio < FechaMaxima) {
            resultados.Add(new DatoDiaCalendarioEquipo(FechaInicio,0));
            FechaInicio = FechaInicio.AddDays(1);
        }
        return new DatosDias(resultados);
    }

    //Dias que cumplen un predicado
    public static List<DatoDiaCalendarioEquipo> FiltroDia(DatosDias dias, Func<DatoDiaCalendarioEquipo, bool> Filtrado) => dias.Where(dia => Filtrado(dia)).ToList();
    //Cuantos dias cumplen un predicado
    public static int NumeroDiasFiltro(DatosDias dias, Func<DatoDiaCalendarioEquipo, bool> Filtrado) => dias.Count(dia => Filtrado(dia));
    //Devuelve verdadero si ningun dia cumple el predicado
    public static bool NingunDiaFiltro(DatosDias dias, Func<DatoDiaCalendarioEquipo, bool> Filtrado) => !dias.Where(dia => Filtrado(dia)).Any();

    /// <summary>
    /// Devuelve los meses de unaño 
    /// </summary>s
    /// <param name="dias">Dias del año</param>
    /// <returns>Diccionario con meses y su número de mes</returns>
    public static Dictionary<int, DatosDias> DividirYearEnMeses(DatosDias dias) {
        Dictionary<int, DatosDias> resultados = new();
        dias.GroupBy(dia => dia.Date.Month)
            .OrderBy(X => X.Key).ToList()
            .ForEach(mes => resultados
            .Add(mes.Key, new DatosDias(mes.ToList())));
        return resultados;
    }

    /// <summary>
    /// De forma paralela aplica un predicado a unos dias
    /// </summary>
    /// <param name="dias"></param>
    /// <param name="accionFiltro"></param>
    public static void AplyFilterToDays(DatosDias dias, Action<DatoDiaCalendarioEquipo> accionFiltro) => dias.AsParallel().ForAll(dia => accionFiltro(dia));
}
