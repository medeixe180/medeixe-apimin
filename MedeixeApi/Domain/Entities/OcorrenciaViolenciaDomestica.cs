using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class OcorrenciaViolenciaDomestica : BaseAuditableEntity
{
    public DateTime DataHoraRegistro { get; set; }
    public DateTime DataHoraAtendimento { get; set; }
    public DateTime DataHoraFinalizacao { get; set; }
    public float Latitude { get; set; }
    public float Longititude { get; set; }
    public string? DescricaoCaso { get; set; }
    public TipoAgressao TipoAgressao { get; set; }
    public NivelPrioridade NivelPrioridade { get; set; }
    public StatusAtendimento StatusAtendimento { get; set; }
    public Vitima Vitima { get; set; }
}