using BananaPay.Data;
using BananaPay.Models;

namespace BananaPay.Services;

public class ContaService(BananaPayContext context)
{
    // ✅ Dependency Injection (SOLID: D)
    private readonly BananaPayContext _context = context;

    // ✅ Single Responsibility (SOLID: S)
    public Conta? CriarConta(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return null;

        bool jaExiste = _context.Contas.Any(c => c.CpfDono == cpf);
        if (jaExiste) return null;

        var conta = new Conta(nome, cpf, senha);

        _context.Contas.Add(conta);

        _context.SaveChanges();

        return conta;
    }

    public bool VerificarLogin(string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return false;

        var cliente = _context.Contas.FirstOrDefault(c => c.CpfDono == cpf);

        return cliente != null && cliente.Senha == senha;
    }

    public void Sacar(decimal valor, string cpf)
    {
        var conta = _context.Contas.FirstOrDefault(c => c.CpfDono == cpf);
        
        if (conta == null) return;

        conta.Debitar(valor);

        conta.Registrar(new Saque(valor, conta.ContaId));

        _context.SaveChanges();

    }

    public void Depositar(decimal valor, string cpf)
    {
        var conta = _context.Contas.FirstOrDefault(c => c.CpfDono == cpf);

        if (conta == null) return;

        conta.Creditar(valor);

        conta.Registrar(new Deposito(valor, conta.ContaId));

        _context.SaveChanges();
    }

    public void Transferir(decimal valor, string cpfDono, string cpfDestino)
    {
        var contaDono = _context.Contas.FirstOrDefault(c => c.CpfDono == cpfDono);
        var contaDestino = _context.Contas.FirstOrDefault(c => c.CpfDono == cpfDestino);

        if (contaDono == null) return;
        if (contaDestino == null) return;

        contaDono.Debitar(valor);
        contaDestino.Creditar(valor);

        contaDono.Registrar(new Transferencia(valor, contaDono.ContaId, contaDestino.ContaId));

        _context.SaveChanges();

    }
}
