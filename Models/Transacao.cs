namespace BananaPay.Models;

public class Transacao
{
    public int TransacaoId { get; set; }
    public decimal Valor { get; set; }
    public TipoTransacao Tipo { get; set; }
    public DateTime DataHora { get; set; } = DateTime.Now;
    public string Descricao { get; set; }
    public int ContaId { get; set; }
    public Conta Conta { get; set; }
}
