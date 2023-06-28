using MedeixeApi.Application.Common.Interfaces;
using MediatR;

namespace MedeixeApi.Application.UseCases;

public record StatusDelete : IRequest
{
    public int Id { get; set; }
}

class StatusAtendimentosDeleteUseCase : IRequestHandler<StatusDelete>
{
    private readonly IApplicationDbContext _context;
    public StatusAtendimentosDeleteUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(StatusDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Status.FindAsync(request.Id);
        if (entity != null)
            _context.Status.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}