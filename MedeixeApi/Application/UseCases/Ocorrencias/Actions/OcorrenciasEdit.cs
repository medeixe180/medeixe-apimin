using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using medeixeApi.Domain.Enums;
using MediatR;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciasEdit : IRequest<Unit>
{
    public int Id { get; set; }
    public string? DescricaoCaso { get; set; }
    public NivelPrioridade NivelPrioridade { get; set; }
    public StatusAtendimento StatusAtendimento { get; set; }
    public int TipoViolenciaId { get; set; }
}

public class OcorrenciaEditUseCase : IRequestHandler<OcorrenciasEdit, Unit>
{
    public readonly IApplicationDbContext _context;

    public OcorrenciaEditUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(OcorrenciasEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Ocorrencias.FindAsync(request.Id);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Ocorrencia), request.Id);
        }

        entity.DataHoraAtendimento = request.StatusAtendimento == StatusAtendimento.Atendendo ? DateTime.Now : null;
        entity.DataHoraFinalizacao = request.StatusAtendimento == StatusAtendimento.Atendido ? DateTime.Now : null;
        entity.DescricaoCaso = request.DescricaoCaso;
        entity.NivelPrioridade = request.NivelPrioridade;
        entity.TipoViolencia = _context.TiposViolencia.Find(request.TipoViolenciaId)!;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }

}