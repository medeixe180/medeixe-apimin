using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.UseCases.Atendentes.Queries;
using MedeixeApi.Application.UseCases.Ocorrencias.Queries;
using MedeixeApi.Application.UseCases.Statuses.Queries;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Movimentacoes.Queries;

public class MovimentacaoDto : IMapFrom<Movimentacao>
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusDto Status { get; set; } = null!;
    public OcorrenciaDto Ocorrencia { get; set; } = null!;
    public AtendenteDto? Atendente { get; set; }
}
