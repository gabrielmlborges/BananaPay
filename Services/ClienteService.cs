using BananaPay.Controller;
using BananaPay.Data;
using BananaPay.Models;

namespace BananaPay.Services;

public class ClienteService
{
    private readonly BananaPayContext _context;

    // ✅ Dependency Injection (SOLID: D)
    public ClienteService(BananaPayContext context)
    {
        _context = context;
    }

    public Cliente? CriarCliente(string nome, string cpfCliente, string senha)
    {
        if (VerificarCliente.Verifica(nome, cpfCliente, senha))
        {
            var cliente = new Cliente(nome, cpfCliente, senha);

            _context.Clientes.Add(cliente);

            _context.SaveChanges();

            ContaService contaService = new(_context);
            var conta = contaService.CriarConta(cliente, cliente.ClienteID);

            _context.Contas.Add(conta);

            _context.SaveChanges();

            return cliente;
        }
        return null;

    }
}