using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.Dto;
using MedeixeApi.Application.DTO.Enums;
using medeixeApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases;

public record UsuarioBrowse : IRequest<UsuariosVm>;

public class UsuarioBrowseHandler : IRequestHandler<UsuarioBrowse, UsuariosVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UsuarioBrowseHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsuariosVm> Handle(UsuarioBrowse request, CancellationToken cancellationToken)
    {
        return new UsuariosVm
        {
            TiposUsuarios = Enum.GetValues(typeof(TipoUsuario))
                .Cast<TipoUsuario>()
                .Select(t => new TipoUsuarioDto
                {
                    Value = (int)t,
                    Name = t.ToString()
                })
                .ToList(),
            Usuarios = await _context.Usuarios
                .AsNoTracking()
                .ProjectTo<UsuarioDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Nome)
                .ToListAsync(cancellationToken)
        };
    }
}

public class UsuariosVm
{
    public IList<TipoUsuarioDto> TiposUsuarios{ get; set; } = new List<TipoUsuarioDto>();
    public IList<UsuarioDto> Usuarios { get; set; } = new List<UsuarioDto>();
}