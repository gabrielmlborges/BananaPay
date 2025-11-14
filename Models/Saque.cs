namespace BananaPay.Models;

public class Saque : Transacao
{
    public override string Tipo { get; set; } = "Saque";
}
