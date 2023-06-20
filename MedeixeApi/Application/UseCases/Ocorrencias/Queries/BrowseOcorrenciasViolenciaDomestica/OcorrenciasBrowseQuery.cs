using AutoMapper;
using AutoMapper.QueryableExtensions;
using medeixeApi.Domain.Enums;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Application.DTO.Enums;
using MedeixeApi.Application.DTO.OcorrenciaDtos;
using MedeixeApi.Application.UseCases.Ocorrencias.Queries.BrowseOcorrenciasViolenciaDomestica;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica
{
    public record OcorrenciasBrowseQuery : IRequest<OcorrenciasVm>;

    public class OcorrenciasBrowseQueryHandler : IRequestHandler<OcorrenciasBrowseQuery, OcorrenciasVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public OcorrenciasBrowseQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OcorrenciasVm> Handle(OcorrenciasBrowseQuery request, CancellationToken cancellationToken)
        {
            return new OcorrenciasVm
            {
                NiveisPrioridade = Enum.GetValues(typeof(NivelPrioridade))
                    .Cast<NivelPrioridade>()
                    .Select(np => new NivelPrioridadeDto
                    {
                        Value = (int)np,
                        Name = np.ToString()
                    })
                    .ToList(),

                Ocorrencias = await _context.Ocorrencias
                    .AsNoTracking()
                    .ProjectTo<OcorrenciaQueryDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.DataHoraRegistro)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}