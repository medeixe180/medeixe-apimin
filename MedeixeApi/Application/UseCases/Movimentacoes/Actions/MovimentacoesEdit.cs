using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using MediatR;

namespace MedeixeApi.Application.UseCases.Movimentacoes.Actions;

public record MovimentacoesEdit : IRequest<int>
{
    public int OcorrenciaId { get; set; }
    public int UsuarioId { get; set; }
    public int StatusId { get; set; }
}

public class MovimentacoesEditUseCase : IRequestHandler<MovimentacoesEdit, int>
{
    private readonly ApplicationDbContext _context;
    
    public MovimentacoesEditUseCase(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(MovimentacoesEdit request, CancellationToken cancellationToken)
    {
        var entity = new Movimentacao
        {
            DataHora = DateTime.Now,
            Status = _context.Status.Find(request.StatusId)!,
            Ocorrencia = _context.Ocorrencias.Find(request.OcorrenciaId)!,
            Atendente = _context.Atendentes.Find(request.UsuarioId)!,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
        };
        
        _context.Movimentacoes.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}