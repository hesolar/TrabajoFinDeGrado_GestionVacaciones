namespace Infrastructure.Repositories;

public class TipoDiaCalendarioRepository : RepositoryBase<Core.Entities.TipoDiaCalendario, int>, ITipoDiaCalendarioRepository {
    public TipoDiaCalendarioRepository(Context context):base(context) {
    }

   
    public override async Task<bool> DeleteByIdAsync(int id)
        => await base.DeleteAsync(_context.TipoDiaCalendario.First(X=> X.Id == id));


    



}
