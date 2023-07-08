using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.UseCases.Movimentacoes.Queries;
using MedeixeApi.Application.UseCases.Usuarios.Queries;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries
{
    public class OcorrenciaDto : IMapFrom<Ocorrencia>
    {
        public int Id { get; set; }
        public DateTime DataHoraRegistro { get; set; }
        public float Latitude { get; set; }
        public float Longititude { get; set; }
        public string? DescricaoCaso { get; set; }
        public UsuarioDto Usuario { get; set; } = null!;
        public TipoViolencia TipoViolencia { get; set; } = null!;
        public List<MovimentacaoDto> Movimentacoes { get; set; } = null!;
    }
}