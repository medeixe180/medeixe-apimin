using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Atendentes.Actions;

public record AtendenteEdit : IRequest<Unit>
{
    public int Id { get; set; }
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public TipoAtendente TipoAtendente { get; set; }
}

public class AtendenteEditHandler : IRequestHandler<AtendenteEdit, Unit>
{
    private IApplicationDbContext _context;

    public AtendenteEditHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AtendenteEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Atendentes.FindAsync(request.Id);
        
        if (entity == null)
            throw new NotFoundException(nameof(Atendente), request.Id);
        
        entity.Cpf = request.Cpf;
        entity.Nome = request.Nome;
        entity.TipoAtendente = request.TipoAtendente;
        entity.LastModified = DateTime.Now;
        entity.LastModifiedBy = null;
        
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}