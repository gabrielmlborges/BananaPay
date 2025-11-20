using BananaPay.Models;

namespace BananaPay.Repository
{
    public interface IContaRepository
    {
        Conta GetByCpf(string cpf);
        Conta GetById(int? id);
        bool ExisteCpf(string cpf);
        void CriarConta(Conta c);
        void Commit();
    }
}
