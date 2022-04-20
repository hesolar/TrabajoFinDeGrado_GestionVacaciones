
namespace Infrastructure.Repositories;
public class EstadoCalendarioVacacionesRepository : IEstadoCalendarioVacacionesRepository {

    EstadoCalendarioVacacionesContext _context;
    RepositoryBase<Core.Entities.EstadoCalendarioVacaciones, int, EstadoCalendarioVacacionesContext> baseOperations;
    public EstadoCalendarioVacacionesRepository(EstadoCalendarioVacacionesContext context) {
        _context = context;
        baseOperations = new(_context);
    }
    public Task<IReadOnlyList<EstadoCalendarioVacaciones>> GetAllAsync() => baseOperations.GetAllAsync();

    public Task<bool> AddAsync(EstadoCalendarioVacaciones entity)
        => throw new NotImplementedException();

    public Task<bool> DeleteAsync(int entity)
     => throw new NotImplementedException();

    public Task<EstadoCalendarioVacaciones> GetByIdAsync(int id)
     => throw new NotImplementedException();

    public Task<bool> UpdateAsync(EstadoCalendarioVacaciones entity)
     => throw new NotImplementedException();

}


