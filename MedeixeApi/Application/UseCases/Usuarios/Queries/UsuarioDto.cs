using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Application.UseCases.Ocorrencias.Queries;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.UseCases.Usuarios.Queries
{
    public class UsuarioDto : IMapFrom<Usuario>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int TipoUsuarioId { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
        public bool MedidaProtetiva { get; set; }
        public List<OcorrenciaDto>? Ocorrencias { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Usuario, UsuarioDto>()
                .ForMember(d => d.TipoUsuarioId, opt => opt.MapFrom(s => (int)s.TipoUsuario));
        }
    }
}
