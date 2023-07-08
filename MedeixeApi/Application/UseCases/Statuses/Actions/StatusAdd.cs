using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases.Statuses.Actions;

public record StatusAdd : IRequest<int>
{
    public string Descricao { get; set; } = null!;
    public bool StatusInicial { get; set; }
}

public class StatusAddUseCase : IRequestHandler<StatusAdd, int>
{
    private readonly IApplicationDbContext _context;
    public StatusAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(StatusAdd request, CancellationToken cancellationToken)
    {
        if (request.StatusInicial == true)
        {
            var entityTrue = _context.Status.Where(t => t.StatusInicial == true).FirstOrDefault();
                if (entityTrue != null)
                    throw new Exception("Não é possível definir mais de um status inicial.");
        }

        var entity = new Status
        { 
            Descricao = request.Descricao,
            StatusInicial = request.StatusInicial,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
        };

        _context.Status.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}