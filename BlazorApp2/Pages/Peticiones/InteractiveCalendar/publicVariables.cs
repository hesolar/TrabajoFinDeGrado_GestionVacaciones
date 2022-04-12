namespace Cal;
public static class PublicVariables {
    public static readonly Dictionary<int, String> Meses = new() {
        [1] = "Enero",
        [2] = "Febrero",
        [3] = "Marzo",
        [4] = "Abril",
        [5] = "Mayo",
        [6] = "Junio",
        [7] = "Julio",
        [8] = "Agosto",
        [9] = "Septiembre",
        [10] = "Octubre",
        [11] = "Noviembre",
        [12] = "Diciembre"
    };

    public static readonly Dictionary<int, DayOfWeek> WeekDays = new() {
        [1] = DayOfWeek.Monday,
        [2] = DayOfWeek.Tuesday,
        [3] = DayOfWeek.Wednesday,
        [4] = DayOfWeek.Thursday,
        [5] = DayOfWeek.Friday,
        [6] = DayOfWeek.Saturday,
        [7] = DayOfWeek.Sunday
    };

}

