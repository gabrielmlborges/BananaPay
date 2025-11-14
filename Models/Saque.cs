namespace BananaPay.Models;

public class Saque(decimal valor, int contaId) : Transacao(valor, contaId)
{
    private Saque() : this(0, 0) { }
    public override string Tipo => "Saque";
}
