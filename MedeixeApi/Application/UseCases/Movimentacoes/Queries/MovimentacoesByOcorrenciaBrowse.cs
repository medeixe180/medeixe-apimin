using AutoMapper;
using AutoMapper.QueryableExtensions;
using MedeixeApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Movimentacoes.Queries;

public record MovimentacoesByOcorrenciaBrowse : IRequest<List<MovimentacaoDto>>
{
    public int OcorrenciaId { get; init; }
}

public class MovimentacoesByOcorrenciaBrowseUseCase : IRequestHandler<MovimentacoesByOcorrenciaBrowse, List<MovimentacaoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public MovimentacoesByOcorrenciaBrowseUseCase(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<MovimentacaoDto>> Handle(MovimentacoesByOcorrenciaBrowse request,
        CancellationToken cancellationToken)
    {
        var movimentacoes = await _context.Movimentacoes.AsNoTracking()
            .ProjectTo<MovimentacaoDto>(_mapper.ConfigurationProvider)
            .Where(p => p.Ocorrencia.Id == request.OcorrenciaId)
            .ToListAsync(cancellationToken);
        return movimentacoes;
    }
}