using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace medeixeApi.Application.DTO.VitimaDtos
{
    public class VitimaQueryDto : IMapFrom<Vitima>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? Idade { get; set; }
        public int Genero { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
        public string? ContatoEmergencia { get; set; }
        public bool MedidaProtetiva { get; set; }
        public List<Ocorrencia>? Ocorrencias { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Vitima, VitimaQueryDto>()
                .ForMember(d => d.Genero, opt => opt.MapFrom(s => (int)s.IdentidadeGenero));
        }
    }
}
