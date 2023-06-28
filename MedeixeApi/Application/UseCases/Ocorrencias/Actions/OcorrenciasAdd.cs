using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciasAdd : IRequest<int>
{
    public float Latitude { get; set; }
    public float Longititude { get; set; }
    public int TipoViolenciaId { get; set; }
    public int VitimaId { get; set; }
}

public class OcorrenciaViolenciaDomesticaAddUseCase : IRequestHandler<OcorrenciasAdd, int>
{
    private readonly IApplicationDbContext _context;

    public OcorrenciaViolenciaDomesticaAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(OcorrenciasAdd request, CancellationToken cancellationToken)
    {
        var entity = new Ocorrencia
        {
            DataHoraRegistro = DateTime.Now,
            Latitude = request.Latitude,
            Longititude = request.Longititude,
            TipoViolencia = _context.TiposViolencia.Find(request.TipoViolenciaId)!,
            NivelPrioridade = NivelPrioridade.Nenhuma,
            Vitima = _context.Vitimas.Find(request.VitimaId)!,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
            Movimentacoes = null,
        };

        _context.Ocorrencias.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}