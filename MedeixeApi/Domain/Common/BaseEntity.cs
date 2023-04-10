using System.ComponentModel.DataAnnotations.Schema;
using medeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
    private readonly List<BaseEvent> _domainEvents = new();
    [NotMapped]
    public IReadOnlyCollection<BaseEvent> DomainEvents => _domainEvents.AsReadOnly();

}