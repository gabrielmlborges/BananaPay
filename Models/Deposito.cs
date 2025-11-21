namespace BananaPay.Models;

public class Deposito(decimal valor, int id) : Transacao(valor, id)
{
    public Deposito() : this(0, 0) { }

    public override string Tipo => "Deposito";
}
