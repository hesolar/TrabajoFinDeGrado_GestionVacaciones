namespace Core.Repositories;

public interface ICalendarioVacacionesRepository : IRepository<CalendarioVacaciones, Tuple<int, DateTime>> {
    public Task<IReadOnlyList<CalendarioVacaciones>> GetDiaUsuario(int idUsuario);
    public Task<IEnumerable<CalendarioVacaciones>> AddNonSavedItems(IEnumerable<CalendarioVacaciones> listado);


}