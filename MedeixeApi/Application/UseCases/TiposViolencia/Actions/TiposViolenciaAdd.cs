using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases.TiposViolencia.Actions;

public record TiposViolenciaAdd : IRequest<int>
{
    public string Descricao { get; set; } = null!;
}

public class TiposViolenciaAddUseCase : IRequestHandler<TiposViolenciaAdd, int>
{
    private readonly IApplicationDbContext _context;
    public TiposViolenciaAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(TiposViolenciaAdd request, CancellationToken cancellationToken)
    {
        var entity = new TipoViolencia
        {
            Descricao = request.Descricao,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null
        };

        _context.TiposViolencia.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}