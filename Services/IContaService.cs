using BananaPay.Models;

namespace BananaPay.Services
{
    public interface IContaService
    {
        bool CriarConta(string nome, string cpf, string senha);
        int? VerificarLogin(string cpf, string senha);
        void Sacar(decimal valor, int? id);
        void Depositar(decimal valor, int? id);
        void Transferir(decimal valor, int? idDono, string cpfDestino);
        decimal AtualizarSaldo(int? id);
        List<Saque> atualizarSaques(int? id);
        List<Deposito> atualizarDepositos(int? id);
        List<Transferencia> atualizarTransferencias(int? id);
        string PegarNomeDeDestino(int? id);
    }
}