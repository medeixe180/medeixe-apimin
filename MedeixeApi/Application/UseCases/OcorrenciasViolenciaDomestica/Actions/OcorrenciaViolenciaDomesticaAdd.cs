using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;

public record OcorrenciaViolenciaDomesticaAdd : IRequest<int>
{
    public float Latitude { get; set; }
    public float Longititude { get; set; }
    public TipoAgressao TipoAgressao { get; set; }
    public int VitimaId { get; set; }
}

public class OcorrenciaViolenciaDomesticaAddUseCase : IRequestHandler<OcorrenciaViolenciaDomesticaAdd, int>
{
    private readonly IApplicationDbContext _context;

    public OcorrenciaViolenciaDomesticaAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(OcorrenciaViolenciaDomesticaAdd request, CancellationToken cancellationToken)
    {
        var entity = new OcorrenciaViolenciaDomestica
        {
            DataHoraRegistro = DateTime.Now,
            DataHoraAtendimento = DateTime.Now,
            DataHoraFinalizacao = DateTime.Now,
            Latitude = request.Latitude,
            Longititude = request.Longititude,
            DescricaoCaso = null,
            TipoAgressao = request.TipoAgressao,
            NivelPrioridade = NivelPrioridade.Nenhuma,
            StatusAtendimento = StatusAtendimento.AguardandoAtendimento,
            Vitima = _context.Vitimas.Find(request.VitimaId),
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null
        };

        _context.OcorrenciasViolenciaDomestica.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}