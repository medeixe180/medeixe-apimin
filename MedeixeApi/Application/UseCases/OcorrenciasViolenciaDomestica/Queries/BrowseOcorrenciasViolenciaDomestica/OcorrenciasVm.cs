namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public class OcorrenciasVm
    {
        public IList<OcorrenciaDto> Ocorrencias { get; set; } = new List<OcorrenciaDto>();
    }
}