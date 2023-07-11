using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.StatusDtos;

public class StatusBriefDto : IMapFrom<Status>
{
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
}