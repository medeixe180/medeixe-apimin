using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases.Statuses.Actions;

public record StatusEdit : IRequest<Unit>
{
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
}

public class StatusEditUseCase : IRequestHandler<StatusEdit, Unit>
{
    public readonly IApplicationDbContext _context;

    public StatusEditUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(StatusEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Status.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ocorrencia), request.Id);
        }

        entity.Descricao = request.Descricao;
        entity.StatusInicial = request.StatusInicial;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}