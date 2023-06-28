using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases;

public record UsuarioEdit : IRequest<Unit>
{
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}

public class UsuarioEditHandler : IRequestHandler<UsuarioEdit, Unit>
{
    private IApplicationDbContext _context;

    public UsuarioEditHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UsuarioEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios.FindAsync(request.Id);
        
        if (entity == null)
            throw new NotFoundException(nameof(Usuario), request.Id);
        
        entity.Cpf = request.Cpf;
        entity.Nome = request.Nome;
        entity.Tipo = request.TipoUsuario;
        entity.LastModified = DateTime.Now;
        entity.LastModifiedBy = null;
        
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}