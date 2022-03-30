namespace Application.Mapper;

public static class MapperBase<MappingProf, O> where MappingProf : Profile, new() {



    /// <summary>
    /// Maps a collection of entries to a output collection
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public static IEnumerable<O> MappIEnumerable(IEnumerable<Object> entities) {

        IMapper Mapper = new Lazy<IMapper>(()
        => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProf>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }).Value;

        foreach (var entity in entities) {
            yield return Mapper.Map<O>(entity);
        }
    }
    /// <summary>
    /// Map an object type to another (O)
    /// </summary>
    /// <param name="entities"></param>
    /// <returns></returns>
    public static O MappEntity(Object entity) {
        IMapper Mapper = new Lazy<IMapper>(()
        => {
            var config = new MapperConfiguration(cfg => {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MappingProf>();
            });
            var mapper = config.CreateMapper();
            return mapper;
        }).Value;
        return Mapper.Map<O>(entity);
    }

}
