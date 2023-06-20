using MedeixeApi.Application.DTO.OcorrenciaDtos;
using MedeixeApi.Application.DTO.Enums;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public class OcorrenciasVm
    {
        public IList<NivelPrioridadeDto> NiveisPrioridade { get; set; } = new List<NivelPrioridadeDto>();
        public IList<OcorrenciaQueryDto> Ocorrencias { get; set; } = new List<OcorrenciaQueryDto>();
    }
}