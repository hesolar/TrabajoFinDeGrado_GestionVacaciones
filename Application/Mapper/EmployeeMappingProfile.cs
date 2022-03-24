namespace Application.Mapper;

public class EmployeeMappingProfile : Profile
{
    public EmployeeMappingProfile()
    {
        CreateMap<Core.Entities.Employee, EmployeeResponse>().ReverseMap();
        CreateMap<Core.Entities.Employee, CreateEmployeeCommand>().ReverseMap();
    }
}
