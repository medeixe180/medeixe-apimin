using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using medeixeApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MedeixeApi.Application.Dto.EnumDtos;
using MedeixeApi.Application.Dto.UsuarioDtos;

namespace MedeixeApi.Application.UseCases.Usuarios.Queries
{
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
                TiposUsuario = Enum.GetValues(typeof(TipoUsuario))
                    .Cast<TipoUsuario>()
                    .Select(g => new TipoUsuarioDto
                    {
                        Value = (int)g,
                        Name = g.ToString()
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
}