using System.Collections.Generic;

namespace BananaPay.Models;

public class Conta
{
    public int ContaId { get; set; }
    public decimal Saldo { get; private set; } = 0;
    public string NomeDono { get; set; }
    public string CpfDono { get; set; }
    public string Senha { get; set; }
    public List<Transacao> Transacoes { get; } = new();

    protected Conta() { }

    public Conta(string NomeDono, string CpfDono, string Senha)
    {
        this.NomeDono = NomeDono,
        this.CpfDono = CpfDono,
        this.Senha = Senha
    }

    public bool Creditar(decimal valor)
    {
        if (valor <= 0) return false;

        Saldo += valor;
        return true;
    }

    public bool Debitar(decimal valor)
    {
        if (valor <= 0 || Saldo < valor) return false;

        Saldo -= valor;

        return true;
    }

    public void Registrar(Transacao t) => Transacoes.Add(t);
}
