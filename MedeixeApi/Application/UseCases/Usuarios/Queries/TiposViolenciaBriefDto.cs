using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries;

public class TiposViolenciaBriefDto : IMapFrom<TipoViolencia>
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
}