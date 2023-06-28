using MedeixeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Vitima> Vitimas { get; }
    DbSet<Ocorrencia> Ocorrencias { get; }
    DbSet<TipoViolencia> TiposViolencia { get; }
    DbSet<Movimentacao> Movimentacoes { get; }
    DbSet<Usuario> Usuarios { get; }
    DbSet<Status> Status { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}