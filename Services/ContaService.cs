using BananaPay.Repository;
using BananaPay.Models;

namespace BananaPay.Services;

public class ContaService(IContaRepository repo)
{
    // ✅ Dependency Injection (SOLID: D)
    private readonly IContaRepository _repo = repo;

    // ✅ Single Responsibility (SOLID: S)
    public bool CriarConta(string nome, string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return false;

        if(!_repo.ExisteCpf(cpf)) return false;

        var conta = new Conta(nome, cpf, senha);

        _repo.CriarConta(conta);

        _repo.Commit();

        return true;
    }

    public bool VerificarLogin(string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return false;

        var cliente = _repo.GetByCpf(cpf);

        return cliente != null && cliente.Senha == senha;
    }

    public void Sacar(decimal valor, string cpf)
    {
        var conta = _repo.GetByCpf(cpf);
        
        if (conta == null) return;

        conta.Debitar(valor, new Saque(valor, conta.ContaId));

        _repo.Commit();

    }

    public void Depositar(decimal valor, string cpf)
    {
        var conta = _repo.GetByCpf(cpf);

        if (conta == null) return;

        conta.Creditar(valor, new Deposito(valor, conta.ContaId));

        _repo.Commit();
    }

    public void Transferir(decimal valor, string cpfDono, string cpfDestino)
    {
        var contaDono = _repo.GetByCpf(cpfDono);
        var contaDestino = _repo.GetByCpf(cpfDestino);

        if (contaDono == null) return;
        if (contaDestino == null) return;

        contaDono.Debitar(valor, new Transferencia(valor, contaDono.ContaId, contaDestino.ContaId));
        contaDestino.Creditar(valor, new Transferencia(valor, contaDestino.ContaId, contaDono.ContaId));

        _repo.Commit();

    }
}
