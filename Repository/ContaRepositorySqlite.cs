using BananaPay.Data;
using BananaPay.Models;

namespace BananaPay.Repository
{
    public class ContaRepositorySqlite(BananaPayContext ctx) : IContaRepository
    {
        private readonly BananaPayContext _context = ctx;

        public Conta GetByCpf(string cpf)
        {
            Conta c = _context.Contas.FirstOrDefault(c => c.CpfDono == cpf);
            return c;
        }

        public bool ExisteCpf(string cpf)
        {
            return _context.Contas.Any(c => c.CpfDono == cpf);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void CriarConta(Conta c) {
            _context.Add(c);
        }

        public List<Transferencia> GetAllTransferencias(int id)
        {
            return _context.Transferencias.Where(t => t.ContaId == id).ToList();
        }

        public List<Saque> GetAllSaques(int id)
        {
            return _context.Saques.Where(t => t.ContaId == id).ToList();
        }

        public List<Deposito> GetAllDepositos(int id)
        {
            return _context.Depositos.Where(t => t.ContaId == id).ToList();
        }

    }
}
