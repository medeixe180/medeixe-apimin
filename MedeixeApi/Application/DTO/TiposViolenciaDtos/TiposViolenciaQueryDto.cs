using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.DTO.TiposViolenciaDtos;

public class TiposViolenciaDto : IMapFrom<TipoViolencia>
{
    public int Id { get; set; }
    public string? Descricao { get; set; }
}