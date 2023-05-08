using MedeixeApi.Application.Common.Interfaces;
using MediatR;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciaViolenciaDomesticaDelete : IRequest
{
    public int Id { get; set; }
}

class OcorrenciaViolenciaDomesticaDeleteUseCase : IRequestHandler<OcorrenciaViolenciaDomesticaDelete>
{
    private readonly IApplicationDbContext _context;
    public OcorrenciaViolenciaDomesticaDeleteUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task Handle(OcorrenciaViolenciaDomesticaDelete request, CancellationToken cancellationToken)
    {
        var entity = await _context.OcorrenciasViolenciaDomestica.FindAsync(request.Id);
        if (entity != null)
            _context.OcorrenciasViolenciaDomestica.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);
    }
}