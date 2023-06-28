using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Vitimas.Actions;

public record VitimaEdit : IRequest<Vitima>
{
    public int Id { get; set; }
    public string? Nome { get; init; }
    public int? Idade { get; init; }
    public IdentidadeGenero IdentidadeGenero { get; init; }
    public string? Endereco { get; init; }
    public string? NumeroTelefone { get; init; }
    public string? Email { get; init; }
    public string? ContatoEmergencia { get; init; }
    public bool MedidaProtetiva { get; init; }
}

public class VitimaEditUseCase : IRequestHandler<VitimaEdit, Vitima>
{
    public readonly IApplicationDbContext _context;

    public VitimaEditUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Vitima> Handle(VitimaEdit request, CancellationToken cancellationToken)
    {
        var entity = await _context.Vitimas.FindAsync(new object[]{ request.Id }, cancellationToken);
        if (entity == null)
            throw new NotFoundException(nameof(Vitima), request.Id);
        entity.Nome = request.Nome;
        entity.Idade = request.Idade;
        entity.IdentidadeGenero = request.IdentidadeGenero;
        entity.Endereco = request.Endereco;
        entity.NumeroTelefone = request.NumeroTelefone;
        entity.Email = request.Email;
        entity.ContatoEmergencia = request.ContatoEmergencia;
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