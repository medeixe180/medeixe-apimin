using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.MovimentacaoDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.StatusDto;

public class StatusDto : IMapFrom<Status>
{
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
    public List<MovimentacaoDto>? Movimentacoes { get; set; }
}