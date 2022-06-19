
using Core.Entities;
using Infraestructure.Data;

namespace Infrastructure.Repositories;
public class CalendarioVacacionesRepository : RepositoryBase<CalendarioVacaciones, Tuple<int, DateTime>>, ICalendarioVacacionesRepository {


    public CalendarioVacacionesRepository(Context context) : base(context) {

    }

    public override async Task<bool> DeleteByIdAsync(Tuple<int, DateTime> entity)
        => await base.DeleteAsync(_context.CalendarioVacaciones.First(x => x.IdTecnico == entity.Item1 && x.FechaCalendario == entity.Item2));

    public async Task<IReadOnlyList<CalendarioVacaciones>> GetDiaUsuario(int idUsuario)
        => await _context.CalendarioVacaciones.Where(x => x.IdTecnico == idUsuario).ToListAsync();




    public async Task<IEnumerable<CalendarioVacaciones>> AddNonSavedItems(IEnumerable<CalendarioVacaciones> listado) {

        IEnumerable<CalendarioVacaciones> except = listado.Where(x => !_context.CalendarioVacaciones.Any(y => x.IdTecnico == y.IdTecnico && x.FechaCalendario == y.FechaCalendario));
        await base.AddManyAsync(except);
        return except;
    }
    public override async Task<CalendarioVacaciones> GetByIdAsync(Tuple<int, DateTime> id) {
        object[] claves = { id.Item1, id.Item2 };
        CalendarioVacaciones d = new();
       CalendarioVacaciones firstItem=(CalendarioVacaciones)  this._context.Find(d.GetType(),claves);
        return firstItem;
    }

}


