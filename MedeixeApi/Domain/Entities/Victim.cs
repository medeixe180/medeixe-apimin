using MedeixeApi.Domain.Common;

namespace MedeixeApi.Domain.Entities;

public class Victim : BaseAuditableEntity
{
    public string? PhoneNumber { get; set; }
    public string? Name { get; set; }
    public bool ProtectiveMeasure { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
}