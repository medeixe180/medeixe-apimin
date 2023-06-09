using AutoMapper;
using medeixeApi.Application.DTO.VitimaDtos;
using MedeixeApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Vitimas.Queries.BrowseVitimas
{
    public record BrowseVitimasQuery : IRequest<List<VitimaQueryDto>>;

    public class BrowseVitimasQueryHandler : IRequestHandler<BrowseVitimasQuery, List<VitimaQueryDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BrowseVitimasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<VitimaQueryDto>> Handle(BrowseVitimasQuery request, CancellationToken cancellationToken)
        {
            var vitimas = await _context.Vitimas.ToListAsync(cancellationToken);
            var vitimasDto = _mapper.Map<List<VitimaQueryDto>>(vitimas);

            return vitimasDto;
        }
    }
}