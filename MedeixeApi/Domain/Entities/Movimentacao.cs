using MedeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Entities;

public class Movimentacao : BaseAuditableEntity
{
    public DateTime DataHora { get; set; }
    public Status Status { get; set; } = null!;
    public Ocorrencia Ocorrencia { get; set; } = null!;
    public Atendente? Atendente { get; set; }
}