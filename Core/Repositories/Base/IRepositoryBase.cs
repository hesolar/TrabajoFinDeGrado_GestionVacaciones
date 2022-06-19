namespace Core.Repositories; 
public interface IRepositoryBase<T, TKey>: IRepository<T,TKey>  where T: class {
}