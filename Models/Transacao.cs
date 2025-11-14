namespace BananaPay.Models;

public abstract class Transacao
{
    public int TransacaoId { get; set; }
    public decimal Valor { get; set; }
    public DateTime DataHora { get; set; } = DateTime.Now;
    public int ContaId { get; set; }
    public Conta Conta { get; set; } = default!;
    public abstract string Tipo { get; }

    public Transacao() { }

    public Transacao(decimal Valor, int ContaId)
    {
        this.Valor = Valor;
        this.ContaId = ContaId;
    }
}
