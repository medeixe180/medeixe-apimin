using MedeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Entities;

public class Ocorrencia : BaseAuditableEntity
{
    public DateTime DataHoraRegistro { get; set; }
    public float Latitude { get; set; }
    public float Longititude { get; set; }
    public Usuario Usuario { get; set; } = null!;
    public TipoViolencia TipoViolencia { get; set; } = null!;
    public List<Movimentacao>? Movimentacoes { get; set; }
}