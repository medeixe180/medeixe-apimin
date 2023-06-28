using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Usuario : BaseAuditableEntity
{
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public TipoUsuario Tipo { get; set; }
    public List<Movimentacao>? Movimentacoes { get; set; }
}