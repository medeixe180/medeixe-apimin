using MedeixeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Vitima> Vitimas { get; }
    DbSet<OcorrenciaViolenciaDomestica> OcorrenciasViolenciaDomestica { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}