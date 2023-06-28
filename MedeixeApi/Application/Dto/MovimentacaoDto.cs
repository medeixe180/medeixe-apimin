using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto;

public class MovimentacaoDto : IMapFrom<Movimentacao>
{
    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public StatusDto Status { get; set; } = null!;
    public Ocorrencia Ocorrencia { get; set; } = null!;
    public Usuario? Usuario { get; set; }
}