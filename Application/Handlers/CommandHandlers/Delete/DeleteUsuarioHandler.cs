using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CommandHandlers;
public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioCommand, bool> {
    private IUsuarioRepository _context;
    public DeleteUsuarioHandler(IUsuarioRepository context) => this._context = context;

    public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken) {
        Core.Entities.Usuario usuarioEntity = UsuarioMapper.Mapper.Map<Core.Entities.Usuario>(request);
        if (usuarioEntity is null) {
            throw new ApplicationException("Issue with mapper");
        }

        return await _context.DeleteAsync(usuarioEntity);
    }


}

