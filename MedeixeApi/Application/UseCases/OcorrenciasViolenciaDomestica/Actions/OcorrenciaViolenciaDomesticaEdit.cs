using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciaViolenciaDomesticaEdit : IRequest<OcorrenciaViolenciaDomestica>
{
    public int Id { get; set; }
    public string? DescricaoCaso { get; set; }
    public NivelPrioridade NivelPrioridade { get; set; }
    public StatusAtendimento StatusAtendimento { get; set; }
}

public class OcorrenciaViolenciaDomesticaEditUseCase : IRequestHandler<OcorrenciaViolenciaDomesticaEdit, OcorrenciaViolenciaDomestica>
{
    public readonly IApplicationDbContext _context;

    public OcorrenciaViolenciaDomesticaEditUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OcorrenciaViolenciaDomestica> Handle(OcorrenciaViolenciaDomesticaEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.OcorrenciasViolenciaDomestica.FindAsync(new object[]{ request.Id }, cancellationToken);
        
        if (entity == null)
            throw new NotFoundException(nameof(OcorrenciaViolenciaDomestica), request.Id);
        
        entity.DescricaoCaso = request.DescricaoCaso;
        entity.NivelPrioridade = request.NivelPrioridade;
        entity.StatusAtendimento = request.StatusAtendimento;
        entity.LastModified = DateTime.Now;
        entity.LastModifiedBy = null;

        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}