namespace Application.Mapper.MappingProfiles;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Core.Entities.Employee, EmployeeResponse>().ReverseMap();
        CreateMap<Core.Entities.Employee, CreateEmployeeCommand>().ReverseMap();
        CreateMap<Core.Entities.Employee, DeleteEmployeeCommand>().ReverseMap();
        CreateMap<Core.Entities.Employee, UpdateEmployeeCommand>().ReverseMap();
    }
}
