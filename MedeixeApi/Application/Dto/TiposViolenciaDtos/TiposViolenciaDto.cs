using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.OcorrenciaDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.TiposViolenciaDtos;

public class TiposViolenciaDto : IMapFrom<TipoViolencia>
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
    public List<OcorrenciaBriefDto>? Ocorrencias { get; set; }
}