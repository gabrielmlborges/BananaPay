namespace BananaPay.Models;

public class Transferencia : Transacao
{
    public int ContaDestinoId { get; set; }
    public Conta ContaDestino { get; set; }

    protected Transferencia() { }

    public Transferencia(decimal v, int contaOrigem, int contaDestino) : base(v, contaOrigem)
    {
        ContaDestinoId = contaDestino;
    }

    public override string Tipo => "Transferencia";
}
