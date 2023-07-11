using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.MovimentacaoDtos;
using MedeixeApi.Application.Dto.TiposViolenciaDtos;
using MedeixeApi.Application.Dto.UsuarioDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.OcorrenciaDtos
{
    public class OcorrenciaDto : IMapFrom<Ocorrencia>
    {
        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public UsuarioBriefDto Usuario { get; set; } = null!;
        public TiposViolenciaBriefDto TipoViolencia { get; set; } = null!;
        public List<MovimentacaoBriefDto> Movimentacoes { get; set; } = null!;
    }
}