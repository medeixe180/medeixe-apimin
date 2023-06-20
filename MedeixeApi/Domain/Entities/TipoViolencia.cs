using MedeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Entities;

public class TipoViolencia : BaseAuditableEntity
{
    public string Descricao { get; set; } = null!;
    public List<Ocorrencia>? Ocorrencias { get; set; }
}