namespace BananaPay.Models;

public class Conta
{
    public int ContaId { get; set; }
    public decimal Saldo { get; private set; } = 0;
    public string NomeDono { get; set; } = default!;
    public string CpfDono { get; set; } = default!;
    public string Senha { get; set; } = default!;
    public List<Transacao> Transacoes { get; } = [];

    private Conta() { }

    public Conta(string nome, string cpf, string senha)
    {
        NomeDono = nome;
        CpfDono = cpf;
        Senha = senha;
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
