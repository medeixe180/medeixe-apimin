using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IMediator _mediator;
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Ocorrencia> Ocorrencias => Set<Ocorrencia>();
    public DbSet<TipoViolencia> TiposViolencia => Set<TipoViolencia>();
    public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();
    public DbSet<Atendente> Atendentes => Set<Atendente>();
    public DbSet<Status> Status => Set<Status>();

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        await _mediator.DispatchDomainEvents(this);
        return await base.SaveChangesAsync(cancellationToken);
    }
}