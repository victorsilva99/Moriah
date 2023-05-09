namespace Moriah.Application.ViewModels;

public class CaixaViewModel
{
    public Guid Id { get; set; }
    public DateTime Data { get; set; }
    public string? NotaString { get; set; }
    public string? MoedaString { get; set; }
    public string? CartaoString { get; set; }

    public decimal Nota { get; set; }
    public decimal Moeda { get; set; }
    public decimal Cartao { get; set; }

    public DateTime CriacaoRegistro { get; set; }
    public DateTime? UltimaAtualizacao { get; set; }

    public decimal? ObterTotal()
        => Nota + Moeda + Cartao;
    
    private static decimal RemoverCifrao(string? valorComCifrao)
    {
        if (string.IsNullOrWhiteSpace(valorComCifrao))
            return 0.00m;

        var valorSemCifrao = valorComCifrao.Replace("R$", "");
        
        if (!decimal.TryParse(valorSemCifrao.Trim(), out var valor))
            throw new ArgumentException($"Valor inválido: {valorComCifrao}");

        return valor;
    }
    
    public void AtualizarValores()
    {
        Nota = RemoverCifrao(NotaString);
        Moeda = RemoverCifrao(MoedaString);
        Cartao = RemoverCifrao(CartaoString);
    }
}