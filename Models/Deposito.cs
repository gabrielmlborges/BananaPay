namespace BananaPay.Models;

public class Deposito : Transacao
{
    public override string Tipo { get; set; } = "Deposito";
}
