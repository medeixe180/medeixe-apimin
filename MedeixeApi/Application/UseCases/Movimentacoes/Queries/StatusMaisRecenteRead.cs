using AutoMapper;
using MedeixeApi.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.UseCases.Movimentacoes.Queries;

public record StatusMaisRecenteRead : IRequest<MovimentacaoDto>
{
    public int OcorrenciaId { get; init; }
}

public class StatusMaisRecenteReadUseCase : IRequestHandler<StatusMaisRecenteRead, MovimentacaoDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public StatusMaisRecenteReadUseCase(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<MovimentacaoDto> Handle(StatusMaisRecenteRead request, CancellationToken cancellationToken)
    {
        var movimentacao = await _context.Movimentacoes
            .AsNoTracking()
            .Where(p => p.Ocorrencia.Id == request.OcorrenciaId)
            .OrderByDescending(p => p.DataHora)
            .FirstOrDefaultAsync(cancellationToken);
        return _mapper.Map<MovimentacaoDto>(movimentacao);
    }
}