
using Core.Entities;

namespace Infrastructure.Repositories;
public class EstadoCalendarioVacacionesRepository : RepositoryBase<Core.Entities.EstadoCalendarioVacaciones, int>, IEstadoCalendarioVacacionesRepository {
    
    public EstadoCalendarioVacacionesRepository(Context context) : base(context){
    }

}


