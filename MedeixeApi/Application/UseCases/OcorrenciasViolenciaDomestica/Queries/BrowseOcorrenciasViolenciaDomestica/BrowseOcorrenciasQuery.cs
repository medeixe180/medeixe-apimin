using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public record BrowseOcorrenciasQuery : IRequest<OcorrenciasVm>;

    public class BrowseOcorrenciasQueryHandler : IRequestHandler<BrowseOcorrenciasQuery, OcorrenciasVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BrowseOcorrenciasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OcorrenciasVm> Handle(BrowseOcorrenciasQuery request, CancellationToken cancellationToken)
        {
            return new OcorrenciasVm {
                Ocorrencias = await _context.OcorrenciasViolenciaDomestica
                    .AsNoTracking()
                    .ProjectTo<OcorrenciaDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}