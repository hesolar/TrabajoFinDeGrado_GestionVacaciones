
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



    public Task<bool> DeleteAsync(CalendarioVacaciones entity)
        => baseOperations.DeleteAsync(entity);

    public Task<IReadOnlyList<CalendarioVacaciones>> GetAllAsync() => baseOperations.GetAllAsync();

    public  Task<CalendarioVacaciones> GetByIdAsync(Tuple<int, DateTime> id) {
        return baseOperations.GetByIdAsync(id);
      
    }

    public Task<bool> UpdateAsync(CalendarioVacaciones entity) {
        var oldEntity = _context.CalendarioVacaciones.First(X => X.IdTecnico == entity.IdTecnico && X.FechaCalendario== entity.FechaCalendario);
        return baseOperations.UpdateAsync(oldEntity, entity);
    }




}


