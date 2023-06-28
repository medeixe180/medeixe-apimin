using MedeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Entities;

public class Status : BaseAuditableEntity
{
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
    public List<Movimentacao>? Movimentacoes { get; set; }
}