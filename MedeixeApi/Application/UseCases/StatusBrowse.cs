using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases;

public record StatusBrowse : IRequest<List<StatusDto>>;

public class StatusBrowseQueryHandler : IRequestHandler<StatusBrowse, List<StatusDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public StatusBrowseQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<List<StatusDto>> Handle(StatusBrowse request, CancellationToken cancellationToken)
    {
        return await _context.Status
            .AsNoTracking()
            .ProjectTo<StatusDto>(_mapper.ConfigurationProvider)
            .OrderBy(t => t.Descricao)
            .ToListAsync(cancellationToken);
    }
}

