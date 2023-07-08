using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases.Atendentes.Actions;

public record AtendenteDelete : IRequest<Unit>
{
    public int Id { get; set; }
}

public class AtendenteDeleteHandler : IRequestHandler<AtendenteDelete, Unit>
{
    private IApplicationDbContext _context;

    public AtendenteDeleteHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(AtendenteDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Atendentes.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Atendente), request.Id);
        }

        _context.Atendentes.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}