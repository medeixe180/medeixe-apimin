using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Usuarios.Actions;

public record UsuarioEdit : IRequest<Usuario>
{
    public int Id { get; set; }
    public string? Nome { get; init; }
    public string? Endereco { get; init; }
    public string? NumeroTelefone { get; init; }
    public string? Email { get; init; }
    public bool MedidaProtetiva { get; init; }
}

public class UsuarioEditUseCase : IRequestHandler<UsuarioEdit, Usuario>
{
    public readonly IApplicationDbContext _context;

    public UsuarioEditUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Usuario> Handle(UsuarioEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Usuarios.FindAsync(new object[]{ request.Id }, cancellationToken);
        if (entity == null)
            throw new NotFoundException(nameof(Usuario), request.Id);
        entity.Nome = request.Nome!;
        entity.Endereco = request.Endereco;
        entity.NumeroTelefone = request.NumeroTelefone;
        entity.Email = request.Email!;
        entity.MedidaProtetiva = request.MedidaProtetiva;
        entity.Ocorrencias = entity.Ocorrencias;
        entity.Created = entity.Created;
        entity.CreatedBy = null;
        entity.LastModified = DateTime.Now;
        entity.LastModifiedBy = null;
        await _context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}