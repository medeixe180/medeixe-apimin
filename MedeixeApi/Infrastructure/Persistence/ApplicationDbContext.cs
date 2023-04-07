using System.Reflection;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MedeixeApi.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Vitima> Vitimas => Set<Vitima>();
    public DbSet<OcorrenciaViolenciaDomestica> OcorrenciasViolenciaDomestica => Set<OcorrenciaViolenciaDomestica>();
}