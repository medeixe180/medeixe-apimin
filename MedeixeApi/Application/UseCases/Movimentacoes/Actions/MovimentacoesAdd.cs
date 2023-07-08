using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using MediatR;

namespace MedeixeApi.Application.UseCases.Movimentacoes.Actions;

public record MovimentacoesAdd : IRequest<int>
{
    public Ocorrencia Ocorrencia { get; set; } = null!;
    public Atendente Atendente { get; set; } = null!;
}

public class MovimentacoesAddUseCase : IRequestHandler<MovimentacoesAdd, int>
{
    private readonly ApplicationDbContext _context;
    
    public MovimentacoesAddUseCase(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(MovimentacoesAdd request, CancellationToken cancellationToken)
    {
        var entity = new Movimentacao
        {
            DataHora = DateTime.Now,
            Status = _context.Status.Where(t => t.StatusInicial == true).FirstOrDefault()!,
            Ocorrencia = _context.Ocorrencias.Find(request.Ocorrencia.Id)!,
            Atendente = null,
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