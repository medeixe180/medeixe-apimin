using AutoMapper;
using MedeixeApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.TiposViolencia.Queries.TiposViolenciaBrowse;

public record TiposViolenciaBrowseQuery : IRequest<List<TiposViolenciaDto>>;

public class TiposViolenciaBrowseQueryHandler : IRequestHandler<TiposViolenciaBrowseQuery, List<TiposViolenciaDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public TiposViolenciaBrowseQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<TiposViolenciaDto>> Handle(TiposViolenciaBrowseQuery request, CancellationToken cancellationToken)
    {
        var tiposViolencia = await _context.TiposViolencia.ToListAsync(cancellationToken);
        var tiposViolenciaDto = _mapper.Map<List<TiposViolenciaDto>>(tiposViolencia);
        
        return tiposViolenciaDto;
    }
}

