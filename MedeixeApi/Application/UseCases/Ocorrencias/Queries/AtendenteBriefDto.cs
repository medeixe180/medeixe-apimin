using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries;

public class AtendenteBriefDto : IMapFrom<Atendente>
{
    public int Id { get; set; }
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public int TipoId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Atendente, AtendenteBriefDto>()
            .ForMember(u => u.TipoId, opt => opt.MapFrom(s => (int)s.TipoAtendente));
    }
}