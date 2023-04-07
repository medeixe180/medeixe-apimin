using medeixeApi.Domain.Enums;

namespace MedeixeApi.Application.Common.Models;

public class VitimaModel
{
    public string? Nome { get; set; }
    public int? Idade { get; set; }
    public Genero Genero { get; set; }
    public string? Endereco { get; set; }
    public string? NumeroTelefone { get; set; }
    public string? Email { get; set; }
    public string? ContatoEmergencia { get; set; }
    public bool MedidaProtetiva { get; set; }
}