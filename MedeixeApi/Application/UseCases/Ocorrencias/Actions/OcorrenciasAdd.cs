using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Actions;

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
        var entityOcorrencia = new Ocorrencia
        {
            DataHoraRegistro = DateTime.Now,
            Latitude = request.Latitude,
            Longititude = request.Longititude,
            TipoViolencia = _context.TiposViolencia.Find(request.TipoViolenciaId)!,
            Usuario = _context.Usuarios.Find(request.VitimaId)!,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
            Movimentacoes = null,
        };
        
        var entityMovimentacao = new Movimentacao
        {
            Atendente = null,
            DataHora = DateTime.Now,
            Ocorrencia = entityOcorrencia,
            Status = _context.Status.Where(s => s.StatusInicial == true).FirstOrDefault()!,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
        };

        _context.Ocorrencias.Add(entityOcorrencia);
        _context.Movimentacoes.Add(entityMovimentacao);
        await _context.SaveChangesAsync(cancellationToken);
        
        return entityOcorrencia.Id;
    }
}