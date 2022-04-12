

namespace Cal;
public static class Core_Calendario {

    /// <summary>
    /// Este metodo actualiza un dia del calendario a otro tipo de dia , hay que tener en cuenta que depende el
    /// tipo de dia el computo total de dias trabajados/vaciones cambiara
    /// </summary>
    /// <param name="calendario">Calendario del trabajador</param>
    /// <param name="dia">Dia a actualizar</param>
    /// <param name="tipoDia">Tipo dia que se quiere actualizar</param>
    /// <returns>el calendario actualizado</returns>
    public static bool ActualizarCalendario(DatosDias dias, DatoDia dia, EstadoDia CambioTipoDia) {
        if (CanUpdateDay(dias, dia, CambioTipoDia)) {
            dia.Estado = CambioTipoDia;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Return true if it can change the state
    /// </summary>
    /// <param name="dias"></param>
    /// <param name="dia"></param>
    /// <param name="nuevoEstado"></param>
    /// <returns></returns>
    public static bool CanUpdateDay(DatosDias dias, DatoDia dia, EstadoDia nuevoEstado) {
        //todo actualizar cuando tenga requerimientos
        switch (nuevoEstado) {
            case EstadoDia.Holiday:
                Func<DatoDia, bool> filtroHoliday = dia => dia.Estado == EstadoDia.Holiday;
                if (Calendario.TotalHolidayDays <= Core_Calendario.NumeroDiasFiltro(dias, filtroHoliday))
                    return false;
                break;
            case EstadoDia.Worked:
                Func<DatoDia, bool> filtroWork = trabajo => dia.Estado == EstadoDia.Worked;
                if (Core_Calendario.NumeroDiasFiltro(dias, filtroWork) > Calendario.DaysMaxToWork)
                    return false;
                break;
        }
        return true;
    }



    /// <summary>
    /// Dado un calendario genera los distintos dias y estados de cada uno de ellos.
    /// </summary>
    /// <param name="calendarioAnual"></param>
    /// <returns></returns>
    public static DatosDias GenerarDiasCalendario(int year) {
        DateTime calendarioActual = new(year, 1, 1);
        DateTime DatosFechasSiguienteAño = new(year + 1, 1, 1);

        List<DatoDia> dias = new();
        while (calendarioActual < DatosFechasSiguienteAño) {
            dias.Add(new DatoDia(calendarioActual));

            calendarioActual = calendarioActual.AddDays(1);
        }
        return new DatosDias(dias);
    }

    public static List<DatoDia> FiltroDia(DatosDias dias, Func<DatoDia, bool> Filtrado) => dias.Where(dia => Filtrado(dia)).ToList();

    public static int NumeroDiasFiltro(DatosDias dias, Func<DatoDia, bool> Filtrado) => dias.Count(dia => Filtrado(dia));

    public static bool NingunDiaFiltro(DatosDias dias, Func<DatoDia, bool> Filtrado) => !dias.Where(dia => Filtrado(dia)).Any();


    public static bool TodosDiasFiltro(DatosDias dias, Func<DatoDia, bool> Filtrado) => dias.All(dia => Filtrado(dia));



    /// <summary>
    /// Devuelve los meses pares
    /// </summary>s
    /// <param name="dias">Dias del año</param>
    /// <returns>febrero,abril,junio,agosto,octubre,diciembre</returns>
    public static Dictionary<int, DatosDias> DividirYearEnMeses(DatosDias dias) {
        Dictionary<int, DatosDias> resultados = new();
        dias.GroupBy(dia => dia.Date.Month)
            .OrderBy(X => X.Key).ToList()
            .ForEach(mes => resultados
            .Add(mes.Key, new DatosDias(mes.ToList())));
        return resultados;
    }

    public static bool ValidarDatosCalendario(DatosDias d) => throw new NotImplementedException();



    public static void AplyFilterToDays(DatosDias dias, Action<DatoDia> accionFiltro) => dias.AsParallel().ForAll(dia => accionFiltro(dia));
}
