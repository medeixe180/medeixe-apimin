using AutoMapper;
using AutoMapper.QueryableExtensions;
using medeixeApi.Application.DTO.VitimaDtos;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.DTO.Enums;
using medeixeApi.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Vitimas.Queries.BrowseVitimas
{
    public record BrowseVitimasQuery : IRequest<VitimasVm>;

    public class BrowseVitimasQueryHandler : IRequestHandler<BrowseVitimasQuery, VitimasVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BrowseVitimasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<VitimasVm> Handle(BrowseVitimasQuery request, CancellationToken cancellationToken)
        {
            return new VitimasVm
            {
                Generos = Enum.GetValues(typeof(Genero))
                    .Cast<Genero>()
                    .Select(g => new GeneroDto
                    {
                        Value = (int)g,
                        Name = g.ToString()
                    })
                    .ToList(),
                Vitimas = await _context.Vitimas
                    .AsNoTracking()
                    .ProjectTo<VitimaQueryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Nome)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}