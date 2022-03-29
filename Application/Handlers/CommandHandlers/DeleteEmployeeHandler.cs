using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers;
public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand,bool> {
    private IEmployeeRepository _context;
    public DeleteEmployeeHandler(IEmployeeRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken) {
        Core.Entities.Employee employeeEntitiy = EmployeeMapper.Mapper.Map<Core.Entities.Employee>(request);
        if (employeeEntitiy is null) {
            throw new ApplicationException("Issue with mapper");
        }

        return await _context.DeleteAsync(employeeEntitiy);
    }


}

