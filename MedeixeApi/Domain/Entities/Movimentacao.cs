using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Movimentacao : BaseAuditableEntity
{
    public DateTime DataHora { get; set; }
    public StatusAtendimento Status { get; set; }
    public Ocorrencia Ocorrencia { get; set; } = null!;
    public Usuario Usuario { get; set; } = null!;
}