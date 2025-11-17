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
    }
}
