using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Ocorrencia : BaseAuditableEntity
{
    public DateTime DataHoraRegistro { get; set; }
    public DateTime? DataHoraAtendimento { get; set; }
    public DateTime? DataHoraFinalizacao { get; set; }
    public float Latitude { get; set; }
    public float Longititude { get; set; }
    public string? DescricaoCaso { get; set; }
    public NivelPrioridade NivelPrioridade { get; set; }
    public Vitima Vitima { get; set; } = null!;
    public TipoViolencia TipoViolencia { get; set; } = null!;
    public List<Movimentacao>? Movimentacoes { get; set; }
}