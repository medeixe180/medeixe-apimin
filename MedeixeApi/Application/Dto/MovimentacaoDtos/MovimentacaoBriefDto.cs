using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.AtendenteDtos;
using MedeixeApi.Application.Dto.StatusDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.MovimentacaoDtos;

public class MovimentacaoBriefDto : IMapFrom<Movimentacao>
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusBriefDto Status { get; set; } = null!;
    public AtendenteBriefDto? Atendente { get; set; }
}
