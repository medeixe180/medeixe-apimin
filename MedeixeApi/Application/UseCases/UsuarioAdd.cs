using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases;

public record UsuarioAdd : IRequest<int>
{
    public string Cpf { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string Senha { get; set; } = null!;
    public TipoUsuario TipoUsuario { get; set; }
}

public class UsuarioAddHandler : IRequestHandler<UsuarioAdd, int>
{
    private IApplicationDbContext _context;

    public UsuarioAddHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UsuarioAdd request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        Usuario entity = _context.Usuarios.Add(new Usuario
        {
            Cpf = request.Cpf,
            Nome = request.Nome,
            Senha = request.Senha,
            Tipo = request.TipoUsuario,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null,
        }).Entity;
        
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}