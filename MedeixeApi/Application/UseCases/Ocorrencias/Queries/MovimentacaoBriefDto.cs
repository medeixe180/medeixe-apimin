using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.UseCases.Statuses.Queries;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries;

public class MovimentacaoBriefDto : IMapFrom<Movimentacao>
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusBriefDto Status { get; set; } = null!;
    public AtendenteBriefDto? Atendente { get; set; }
}
