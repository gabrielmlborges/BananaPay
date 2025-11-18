using BananaPay.Models;

namespace BananaPay.Repository
{
    public interface IContaRepository
    {
        Conta GetByCpf(string cpf);
        bool ExisteCpf(string cpf);
        void CriarConta(Conta c);
        void Commit();
    }
}
