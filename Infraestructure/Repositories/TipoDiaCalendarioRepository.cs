﻿namespace Infrastructure.Repositories;

public class TipoDiaCalendarioRepository : ITipoDiaCalendarioRepository {

    TipoDiaCalendarioContext _context;
    RepositoryBase<Core.Entities.TipoDiaCalendario, int, TipoDiaCalendarioContext> baseOperations;
    public TipoDiaCalendarioRepository(TipoDiaCalendarioContext context) {
        _context = context;
        baseOperations = new(_context);
    }

    public async Task<bool> AddAsync(TipoDiaCalendario entity)
        => await baseOperations.AddAsync(entity);

    public async Task<bool> DeleteAsync(int id){
        throw new NotImplementedException();
    }

    public async Task<IReadOnlyList<TipoDiaCalendario>> GetAllAsync() {

        var listado = _context.TipoDiaCalendario.ToList();
        return listado;
    }
         //=> await baseOperations.GetAllAsync();

    public async Task<TipoDiaCalendario> GetByIdAsync(int id) {
        var a =  _context.TipoDiaCalendario.First(X=> X.Id==id);
        return a;
    }
    //=> await baseOperations.GetByIdAsync(id);

    public async Task<bool> UpdateAsync(TipoDiaCalendario entity) 
         => throw new NotImplementedException();


}
