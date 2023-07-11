using AutoMapper;
using MedeixeApi.Application.Common.Mappings;
using MedeixeApi.Domain.Entities;

namespace MedeixeApi.Application.Dto.UsuarioDtos
{
    public class UsuarioBriefDto : IMapFrom<Usuario>
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public int TipoUsuarioId { get; set; }
        public string? Endereco { get; set; }
        public string? NumeroTelefone { get; set; }
        public string? Email { get; set; }
        public bool MedidaProtetiva { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Usuario, UsuarioBriefDto>()
                .ForMember(d => d.TipoUsuarioId, opt => opt.MapFrom(s => (int)s.TipoUsuario));
        }
    }
}
