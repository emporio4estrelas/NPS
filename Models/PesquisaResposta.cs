namespace PesquisaSatisfacaoApi.Models
{
    public class PesquisaResposta
    {
        public int Id { get; set; }
        public string? Q1 { get; set; }
        public string? Q2 { get; set; }
        public string? Comentario { get; set; }
        public string Pdv { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
