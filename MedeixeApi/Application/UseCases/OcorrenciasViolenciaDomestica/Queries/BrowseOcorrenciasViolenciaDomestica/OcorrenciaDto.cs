using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public class OcorrenciaDto : IMapFrom<OcorrenciaViolenciaDomestica>
    {
        public OcorrenciaDto()
        {
            TipoAgressao = new TipoAgressaoDto();
            NivelPrioridade = new NivelPrioridadeDto();
            StatusAtendimento = new StatusAtendimentoDto();
            Vitima = new VitimaDto();
        }

        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public DateTime DataHoraFinalizacao { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public string? DescricaoCaso { get; set; }
        public TipoAgressaoDto TipoAgressao { get; set; }
        public NivelPrioridadeDto NivelPrioridade { get; set; }
        public StatusAtendimentoDto StatusAtendimento { get; set; }
        public VitimaDto Vitima { get; set; }

    }
}