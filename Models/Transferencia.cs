namespace BananaPay.Models;

public class Transferencia : Transacao
{
    public int ContaDestinoId { get; set; }
    public Conta ContaDestino { get; set; }
    public override string Tipo { get; set; } = "Transferencia";

    protected Transferencia() { }

    public Transferencia(decimal v, int contaOrigem, int contaDestino) : base(v, contaOrigem)
    {
        ContaDestinoId = contaDestino;
    }


}
