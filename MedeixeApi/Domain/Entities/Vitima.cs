using System.ComponentModel.DataAnnotations;
using MedeixeApi.Domain.Common;
using medeixeApi.Domain.Enums;

namespace MedeixeApi.Domain.Entities;

public class Vitima : BaseAuditableEntity
{
    public string? Nome { get; set; }
    public int? Idade { get; set; }
    public Genero Genero { get; set; }
    public string? Endereco { get; set; }
    public string? NumeroTelefone { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    public string? ContatoEmergencia { get; set; }
    public bool MedidaProtetiva { get; set; }
    public List<OcorrenciaViolenciaDomestica>? Ocorrencias { get; set; }
}
