using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public class OcorrenciaDto : IMapFrom<OcorrenciaViolenciaDomestica>
    {
        public OcorrenciaDto()
        {
            Vitima = new VitimaDto();
        }

        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public DateTime DataHoraFinalizacao { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public string? DescricaoCaso { get; set; }
        public int TipoAgressao { get; set; }
        public int NivelPrioridade { get; set; }
        public int StatusAtendimento { get; set; }
        public VitimaDto Vitima { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<OcorrenciaViolenciaDomestica, OcorrenciaDto>()
                .ForMember(d => d.TipoAgressao, opt => opt.MapFrom(s => (int)s.TipoAgressao))
                .ForMember(d => d.NivelPrioridade, opt => opt.MapFrom(s => (int)s.NivelPrioridade))
                .ForMember(d => d.StatusAtendimento, opt => opt.MapFrom(s => (int)s.StatusAtendimento));
        }
    }
}