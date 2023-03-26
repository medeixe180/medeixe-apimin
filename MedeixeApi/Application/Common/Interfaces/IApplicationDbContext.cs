using MedeixeApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Victim> Victims { get; }
}