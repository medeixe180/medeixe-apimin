using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Atendente : BaseAuditableEntity
{
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public TipoAtendente TipoAtendente { get; set; }
    public List<Movimentacao>? Movimentacoes { get; set; }
}