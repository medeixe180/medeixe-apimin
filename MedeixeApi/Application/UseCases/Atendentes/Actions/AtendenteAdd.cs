using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Atendentes.Actions;

public record AtendenteAdd : IRequest<int>
{
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public TipoAtendente TipoAtendente { get; set; }
}

public class AtendenteAddHandler : IRequestHandler<AtendenteAdd, int>
{
    private IApplicationDbContext _context;

    public AtendenteAddHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(AtendenteAdd request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        Atendente entity = _context.Atendentes.Add(new Atendente
        {
            Cpf = request.Cpf,
            Nome = request.Nome,
            Senha = request.Senha,
            TipoAtendente = request.TipoAtendente,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
        }).Entity;
        
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}