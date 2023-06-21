using MedeixeApi.Application.DTO.Enums;
using medeixeApi.Application.DTO.VitimaDtos;

namespace MedeixeApi.Application.UseCases.Vitimas.Queries.BrowseVitimas;

public class VitimasVm
{
    public IList<GeneroDto> Generos { get; set; } = new List<GeneroDto>();
    public IList<VitimaQueryDto> Vitimas { get; set; } = new List<VitimaQueryDto>();
}