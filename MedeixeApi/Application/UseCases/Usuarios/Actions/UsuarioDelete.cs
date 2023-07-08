using MedeixeApi.Application.Common.Interfaces;
using MediatR;

namespace MedeixeApi.Application.UseCases.Usuarios.Actions;

public record UsuarioDelete : IRequest
{
    public int Id { get; set; }
}

class UsuarioDeleteUseCase : IRequestHandler<UsuarioDelete>
{
    private readonly IApplicationDbContext _context;
    public UsuarioDeleteUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(UsuarioDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios.FindAsync(request.Id);
        if (entity != null)
            _context.Usuarios.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}