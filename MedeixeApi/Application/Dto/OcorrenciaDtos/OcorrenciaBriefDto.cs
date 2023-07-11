using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.TiposViolenciaDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.OcorrenciaDtos
{
    public class OcorrenciaBriefDto : IMapFrom<Ocorrencia>
    {
        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public TiposViolenciaBriefDto TipoViolencia { get; set; } = null!;
    }
}