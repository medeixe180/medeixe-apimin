using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica;
public class VitimaDto : IMapFrom<Vitima>
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
    public void Mapping(Profile profile)
    {
        profile.CreateMap<Vitima, VitimaDto>()
            .ForMember(d => d.Genero, opt => opt.MapFrom(s => (int)s.Genero));
    }
}