using System.ComponentModel.DataAnnotations;
using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Usuario : BaseAuditableEntity
{
    public string Nome { get; set; } = null!;
    public DateTime? DataNascimento { get; set; }
    public string? Endereco { get; set; }
    public string? NumeroTelefone { get; set; }
    [EmailAddress]
    public string Email { get; set; } = null!;
    public bool MedidaProtetiva { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
    public List<Ocorrencia>? Ocorrencias { get; set; }
}
