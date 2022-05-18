
using AutoMapper;

namespace BlazorApp2.Shared;
/// <summary>
/// Mapper entre dos objetos
/// </summary>
/// <typeparam name="I">Tipo de objeto de entrada</typeparam>
/// <typeparam name="O">Tipo de objeto de salida</typeparam>
public static class MapFrom<I,O>{ 
    public static O Map(I input) {
        var config = new MapperConfiguration(cfg => cfg.CreateMap<I, O>());
        var mapper = new Mapper(config);    
        O output = mapper.Map<O>(input);
        return output;
    }

}