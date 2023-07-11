using MedeixeApi.Application.Dto.EnumDtos;
using MedeixeApi.Application.Dto.UsuarioDtos;

namespace MedeixeApi.Application.UseCases.Usuarios.Queries;

public class UsuariosVm
{
    public IList<TipoUsuarioDto> TiposUsuario { get; set; } = new List<TipoUsuarioDto>();
    public IList<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
}