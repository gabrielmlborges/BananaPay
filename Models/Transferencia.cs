namespace BananaPay.Models;

public class Transferencia(decimal valor, int contaId, string Desc, int destinoId) : Transacao(valor, contaId, Desc)
{
    public int ContaDestinoId { get; set; } = destinoId;
    public Conta ContaDestino { get; set; } = default!;

    public Transferencia() : this(0, 0, "", 0) { }

    public override string Tipo => "Transferencia";
}
