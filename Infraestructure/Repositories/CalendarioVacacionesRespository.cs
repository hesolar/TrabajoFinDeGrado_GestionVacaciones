
namespace Infrastructure.Repositories;
public class CalendarioVacacionesRepository : ICalendarioVacacionesRepository {

    CalendarioVacacionesContext _context;
    RepositoryBase<Core.Entities.CalendarioVacaciones, Tuple<int, DateTime>, CalendarioVacacionesContext> baseOperations;
    public CalendarioVacacionesRepository(CalendarioVacacionesContext context) {
        _context = context;
        baseOperations = new(_context);

    }

    public Task<bool> AddAsync(CalendarioVacaciones entity) {
        return baseOperations.AddAsync(entity);
    }



    public Task<bool> DeleteAsync(Tuple<int, DateTime> entity)
        => baseOperations.DeleteAsync(_context.CalendarioVacaciones.First(x => x.IdTecnico == entity.Item1 && x.FechaCalendario == entity.Item2));

    public Task<IReadOnlyList<CalendarioVacaciones>> GetAllAsync() => baseOperations.GetAllAsync();

    public async Task<CalendarioVacaciones> GetByIdAsync(Tuple<int, DateTime> id) {
        return await _context.Set<CalendarioVacaciones>().FindAsync(id.Item1, id.Item2);

    }

    public async Task<IReadOnlyList<CalendarioVacaciones>> GetDiaUsuario(int idUsuario)
        => await _context.CalendarioVacaciones.Where(x => x.IdTecnico == idUsuario).ToListAsync();


    public Task<bool> UpdateAsync(CalendarioVacaciones entity) {
        var oldEntity = _context.CalendarioVacaciones.First(X => X.IdTecnico == entity.IdTecnico && X.FechaCalendario == entity.FechaCalendario);
        return baseOperations.UpdateAsync(oldEntity, entity);
    }

    public async Task<IEnumerable<CalendarioVacaciones>> AddNonSavedItems(IEnumerable<CalendarioVacaciones> listado) {

        IEnumerable<CalendarioVacaciones> except = listado.Where(x => !_context.CalendarioVacaciones.Any(y => x.IdTecnico == y.IdTecnico && x.FechaCalendario == y.FechaCalendario));
        await baseOperations.AddManyAsync(except);
        return except;
    }

}


