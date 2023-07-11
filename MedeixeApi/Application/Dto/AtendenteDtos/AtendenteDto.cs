using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.Dto.MovimentacaoDtos;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.AtendenteDtos;

public class AtendenteDto : IMapFrom<Atendente>
{
    public int Id { get; set; }
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public int TipoId { get; set; }
    public List<MovimentacaoBriefDto>? Movimentacoes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Atendente, AtendenteDto>()
            .ForMember(u => u.TipoId, opt => opt.MapFrom(s => (int)s.TipoAtendente));
    }
}