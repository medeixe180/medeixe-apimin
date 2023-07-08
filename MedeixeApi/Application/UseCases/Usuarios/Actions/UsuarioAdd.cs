using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using medeixeApi.Domain.Enums;
using MediatR;

namespace MedeixeApi.Application.UseCases.Usuarios.Actions;

public record UsuarioAdd : IRequest<int>
{
    public string? Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Endereco { get; set; }
    public string? NumeroTelefone { get; set; }
    public string? Email { get; set; }
    public bool MedidaProtetiva { get; set; }
    public TipoUsuario TipoUsuario { get; set; }
}

public class UsuarioAddUseCase : IRequestHandler<UsuarioAdd, int>
{
    private readonly IApplicationDbContext _context;

    public UsuarioAddUseCase(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(UsuarioAdd request, CancellationToken cancellationToken)
    {
        var vitima = new Usuario
        {
            Nome = request.Nome!,
            DataNascimento = request.DataNascimento,
            Endereco = request.Endereco,
            NumeroTelefone = request.NumeroTelefone,
            Email = request.Email!,
            MedidaProtetiva = request.MedidaProtetiva,
            TipoUsuario = request.TipoUsuario,
            Ocorrencias = null,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null
        };

        _context.Usuarios.Add(vitima);
        await _context.SaveChangesAsync(cancellationToken);
        return vitima.Id;
    }
}