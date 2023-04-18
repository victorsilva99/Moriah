namespace Moriah.Domain.Entities;

public class Caixa
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public double? Nota { get; set; }
    public double? Moeda { get; set; }
    public double? Cartao_Debito { get; set; }
    public double? Cartao_Credito { get; set; }
}
