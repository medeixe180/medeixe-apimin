using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public record BrowseOcorrenciasQuery : IRequest<List<OcorrenciaViolenciaDomestica>>;

    public class BrowseOcorrenciasQueryHandler : IRequestHandler<BrowseOcorrenciasQuery, List<OcorrenciaViolenciaDomestica>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BrowseOcorrenciasQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OcorrenciaViolenciaDomestica>> Handle(BrowseOcorrenciasQuery request, CancellationToken cancellationToken)
        {
            return await _context.OcorrenciasViolenciaDomestica
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            // return new OcorrenciasVm 
            // {
            //     Ocorrencias = await _context.OcorrenciasViolenciaDomestica
            //         .AsNoTracking()
            //         .ProjectTo<OcorrenciaDto>(_mapper.ConfigurationProvider)
            //         .ToListAsync(cancellationToken)
            // };
        }
    }
}