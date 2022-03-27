namespace Application.Mapper;

public class UsuarioMapper {
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => {
        var config = new MapperConfiguration(cfg => {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<UsuarioMappingProfile>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });
    public static IMapper Mapper => Lazy.Value;
}
