using BananaPay.Models;

namespace BananaPay.Repository
{
    public interface IContaRepository
    {
        Conta GetByCpf(string cpf);
        Conta GetById(int? id);
        decimal GetSaldo(int? id);
        bool ExisteCpf(string cpf);
        void CriarConta(Conta c);
        void Commit();
        List<Saque> GetAllSaques(int? id);
        List<Deposito> GetAllDepositos(int? id);
        List<Transferencia> GetAllTransferencias(int? id);
        string GetName(int? id);
    }
}
