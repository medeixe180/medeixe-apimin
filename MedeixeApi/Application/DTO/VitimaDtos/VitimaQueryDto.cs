using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace medeixeApi.Application.DTO.VitimaDtos
{
    public class VitimaQueryDto : IMapFrom<Vitima>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
    }
}
