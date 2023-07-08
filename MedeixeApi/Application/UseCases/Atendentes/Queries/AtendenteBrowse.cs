using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.DTO.Enums;
using medeixeApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Atendentes.Queries;

public record AtendenteBrowse : IRequest<AtendentesVm>;

public class AtendenteBrowseHandler : IRequestHandler<AtendenteBrowse, AtendentesVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AtendenteBrowseHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AtendentesVm> Handle(AtendenteBrowse request, CancellationToken cancellationToken)
    {
        return new AtendentesVm
        {
            TiposUsuarios = Enum.GetValues(typeof(TipoAtendente))
                .Cast<TipoAtendente>()
                .Select(t => new TipoAtendenteDto
                {
                    Value = (int)t,
                    Name = t.ToString()
                })
                .ToList(),
            Usuarios = await _context.Atendentes
                .AsNoTracking()
                .ProjectTo<AtendenteDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.Nome)
                .ToListAsync(cancellationToken)
        };
    }
}

public class AtendentesVm
{
    public IList<TipoAtendenteDto> TiposUsuarios{ get; set; } = new List<TipoAtendenteDto>();
    public IList<AtendenteDto> Usuarios { get; set; } = new List<AtendenteDto>();
}