namespace Moriah.Application.ViewModels
{
    public class CaixaViewModel
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public decimal? Nota { get; set; }
        public decimal? Moeda { get; set; }
        public decimal? Cartao { get; set; }
        public DateTime CriacaoRegistro { get; set; }
        public DateTime? UltimaAtualizacao { get; set; }
    }
}


