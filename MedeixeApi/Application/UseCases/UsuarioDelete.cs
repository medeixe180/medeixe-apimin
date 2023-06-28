using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases;

public record UsuarioDelete : IRequest<Unit>
{
    public int Id { get; set; }
}

public class UsuarioDeleteHandler : IRequestHandler<UsuarioDelete, Unit>
{
    private IApplicationDbContext _context;

    public UsuarioDeleteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UsuarioDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Usuario), request.Id);
        }

        _context.Usuarios.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}