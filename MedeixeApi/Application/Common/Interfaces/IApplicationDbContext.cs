using MedeixeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Usuario> Usuarios { get; }
    DbSet<Ocorrencia> Ocorrencias { get; }
    DbSet<TipoViolencia> TiposViolencia { get; }
    DbSet<Movimentacao> Movimentacoes { get; }
    DbSet<Atendente> Atendentes { get; }
    DbSet<Status> Status { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}