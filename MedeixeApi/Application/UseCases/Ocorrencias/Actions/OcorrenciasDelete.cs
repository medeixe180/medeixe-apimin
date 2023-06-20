using MedeixeApi.Application.Common.Interfaces;
using MediatR;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciasDelete : IRequest
{
    public int Id { get; set; }
}

class OcorrenciaViolenciaDomesticaDeleteUseCase : IRequestHandler<OcorrenciasDelete>
{
    private readonly IApplicationDbContext _context;
    public OcorrenciaViolenciaDomesticaDeleteUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(OcorrenciasDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.Ocorrencias.FindAsync(request.Id);
        if (entity != null)
            _context.Ocorrencias.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}