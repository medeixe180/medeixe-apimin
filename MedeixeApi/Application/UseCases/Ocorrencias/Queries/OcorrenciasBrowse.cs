using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.Dto.OcorrenciaDtos;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Ocorrencias.Queries
{
    public record OcorrenciasBrowse : IRequest<List<OcorrenciaDto>>;

    public class OcorrenciasBrowseUseCase : IRequestHandler<OcorrenciasBrowse, List<OcorrenciaDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OcorrenciasBrowseUseCase(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OcorrenciaDto>> Handle(OcorrenciasBrowse request, CancellationToken cancellationToken)
        {
             return await _context.Ocorrencias
                .AsNoTracking()
                .ProjectTo<OcorrenciaDto>(_mapper.ConfigurationProvider)
                .OrderBy(t => t.DataHoraRegistro)
                .ToListAsync(cancellationToken);
        }
    }
}