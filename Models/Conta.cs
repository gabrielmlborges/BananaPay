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

    public bool Depositar(decimal valor, string descricao = "Deposito")
    {
        if (valor <= 0) return false;

        Saldo += valor;

        Transacoes.Add(new Transacao
        {
            Valor = valor,
            Tipo = TipoTransacao.Deposito,
            Descricao = descricao,
            ContaId = this.ContaId
        });

        return true;
    }

    public bool Sacar(decimal valor, string descricao = "Saque")
    {
        if (valor <= 0 || Saldo < valor) return false;

        Saldo -= valor;

        Transacoes.Add(new Transacao
        {
            Valor = valor,
            Tipo = TipoTransacao.Saque,
            Descricao = descricao,
            ContaId = this.ContaId
        });

        return true;
    }
}
