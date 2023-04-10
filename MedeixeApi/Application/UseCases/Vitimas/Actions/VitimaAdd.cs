using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Vitimas.Actions;

public record VitimaAdd : IRequest<int>
{
    public string? Nome { get; init; }
    public int? Idade { get; init; }
    public Genero Genero { get; init; }
    public string? Endereco { get; init; }
    public string? NumeroTelefone { get; init; }
    public string? Email { get; init; }
    public string? ContatoEmergencia { get; init; }
    public bool MedidaProtetiva { get; init; }
}

public class VitimaAddUseCase : IRequestHandler<VitimaAdd, int>
{
    private readonly IApplicationDbContext _context;

    public VitimaAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(VitimaAdd request, CancellationToken cancellationToken)
    {
        var vitima = new Vitima
        {
            Nome = request.Nome,
            Idade = request.Idade,
            Genero = request.Genero,
            Endereco = request.Endereco,
            NumeroTelefone = request.NumeroTelefone,
            Email = request.Email,
            ContatoEmergencia = request.ContatoEmergencia,
            MedidaProtetiva = request.MedidaProtetiva,
            Ocorrencias = null,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null
        };

        _context.Vitimas.Add(vitima);
        await _context.SaveChangesAsync(cancellationToken);
        return vitima.Id;
    }
}