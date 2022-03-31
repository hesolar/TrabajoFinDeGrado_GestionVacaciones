namespace Application.Operations.Queries;

public class GetEmployeeByIdQuery: IRequest<EmployeeResponse> {
    public int Id { get; set; }
}

