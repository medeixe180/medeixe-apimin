using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Application.Dto;

public class UsuarioDto : IMapFrom<Usuario>
{
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public int TipoUsuarioId { get; set; }
    public List<Movimentacao>? Movimentacoes { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Usuario, UsuarioDto>()
            .ForMember(u => u.TipoUsuarioId, opt => opt.MapFrom(s => (int)s.Tipo));
    }
}