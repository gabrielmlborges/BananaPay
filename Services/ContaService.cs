using BananaPay.Data;
using BananaPay.Models;

namespace BananaPay.Services;

public class ContaService
{
    private readonly BananaPayContext _context;

    // ✅ Dependency Injection (SOLID: D)
    public ContaService(BananaPayContext context)
    {
        _context = context;
    }

    // ✅ Single Responsibility (SOLID: S)
    public Conta? CriarConta(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return null;

        bool jaExiste = _context.Contas.Any(c => c.CpfDono == cpf);
        if (jaExiste) return null;

        var conta = new Conta
        {
            NomeDono = nome,
            CpfDono = cpf,
            Senha = senha
        };

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
}
