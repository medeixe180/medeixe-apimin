using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.DTO.OcorrenciaDtos
{
    public class OcorrenciaQueryDto : IMapFrom<Ocorrencia>
    {

        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public DateTime? DataHoraAtendimento { get; set; }
        public DateTime? DataHoraFinalizacao { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public string? DescricaoCaso { get; set; }
        public int NivelPrioridade { get; set; }
        public Vitima Vitima { get; set; } = null!;
        public TipoViolencia TipoViolencia { get; set; } = null!;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Ocorrencia, OcorrenciaQueryDto>()
                .ForMember(d => d.NivelPrioridade, opt => opt.MapFrom(s => (int)s.NivelPrioridade));
        }
    }
}