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

        if(_repo.ExisteCpf(cpf)) return false;

        var conta = new Conta(nome, cpf, senha);

        _repo.CriarConta(conta);

        _repo.Commit();

        return true;
    }

    public int? VerificarLogin(string cpf, string senha)
    {
        if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(senha)) return null;

        var conta = _repo.GetByCpf(cpf);

        if (conta == null || conta.Senha != senha) return null;

        return conta.ContaId;
    }

    public void Sacar(decimal valor, int? id)
    {
        var conta = _repo.GetById(id);
        
        if (conta == null) return;

        conta.Debitar(valor, new Saque(valor, conta.ContaId));

        _repo.Commit();

    }

    public void Depositar(decimal valor, int? id)
    {
        var conta = _repo.GetById(id);

        if (conta == null) return;

        conta.Creditar(valor, new Deposito(valor, conta.ContaId));

        _repo.Commit();
    }

    public void Transferir(decimal valor, int? idDono, string cpfDestino)
    {
        var contaDono = _repo.GetById(idDono);
        var contaDestino = _repo.GetByCpf(cpfDestino);

        if (contaDono == null) return;
        if (contaDestino == null) return;

        contaDono.Debitar(valor, new Transferencia(valor, contaDono.ContaId, contaDestino.ContaId));
        contaDestino.Creditar(valor, new Transferencia(valor, contaDestino.ContaId, contaDono.ContaId));

        _repo.Commit();

    }

    public decimal AtualizarSaldo(int? id)
    {
        return _repo.GetSaldo(id);
    }

}
