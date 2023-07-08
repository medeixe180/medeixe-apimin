using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Statuses.Queries;

public class StatusDto : IMapFrom<Status>
{
    public int Id { get; set; }
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
}