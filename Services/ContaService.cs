using BananaPay.Controller;
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
    public Conta? CriarConta(Cliente cliente, int clienteId)
    {
        if (VerificarConta.Verifica(cliente, clienteId))
        {
            var conta = new Conta(cliente, clienteId);

            _context.Contas.Add(conta);

            _context.SaveChanges();

            return conta;
        }
        return null;
    }

    public bool VerificarLogin(string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return false;

        var cliente = _context.Clientes.FirstOrDefault(c => c.CpfDono == cpf);

        return cliente != null && cliente.Senha == senha;
    }
}
