using MedeixeApi.Application.Common.Interfaces;
using MediatR;

namespace MedeixeApi.Application.UseCases.Vitimas.Actions;

public record VitimaDelete : IRequest
{
    public int Id { get; set; }
}

class VitimaDeleteUseCase : IRequestHandler<VitimaDelete>
{
    private readonly IApplicationDbContext _context;
    public VitimaDeleteUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(VitimaDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vitimas.FindAsync(request.Id);
        if (entity != null)
            _context.Vitimas.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}