using MedeixeApi.Application.DTO.Enums;

namespace MedeixeApi.Application.UseCases.Usuarios.Queries;

public class UsuariosVm
{
    public IList<TipoUsuarioDto> TiposUsuario { get; set; } = new List<TipoUsuarioDto>();
    public IList<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
}