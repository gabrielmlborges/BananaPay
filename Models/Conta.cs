using System.Collections.Generic;

namespace BananaPay.Models;

public class Conta
{
    public int ContaId { get; set; }
    public decimal Saldo { get; private set; } = 0;
    public int ClienteID { get; set; }
    public Cliente Cliente { get; set; }

    public List<Transacao> Transacoes { get; } = new();

    protected Conta() { }

    public Conta(Cliente cliente, int clienteId)
    {
        Cliente = cliente;
        ClienteID = clienteId;
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
