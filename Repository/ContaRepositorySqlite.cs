using System.Data;
using BananaPay.Data;
using BananaPay.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

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

        public Conta GetById(int? id)
        {
            return _context.Contas.FirstOrDefault(c => c.ContaId == id);
        }

        public decimal GetSaldo(int? id)
        {
            var conta = _context.Contas.FirstOrDefault(c => c.ContaId == id);
            return conta.Saldo;
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

        public List<Transferencia> GetAllTransferencias(int? id)
        {
            return _context.Transferencias.Where(t => t.ContaId == id).ToList();
        }

        public List<Saque> GetAllSaques(int? id)
        {
            return _context.Saques.Where(t => t.ContaId == id).ToList();
        }

        public List<Deposito> GetAllDepositos(int? id)
        {
            return _context.Depositos.Where(t => t.ContaId == id).ToList();
        }

        public string GetName(int? id)
        {
            var conta = _context.Contas.FirstOrDefault(t => t.ContaId == id);
            return conta.NomeDono;
        }

        //FUNCIONALIDADE QUE UTILIZA MANIPULAÇÃO SQL
        public List<string> ObterTiposTransacaoSqlRaw(int contaId)
        {
            var conn = _context.Database.GetDbConnection();
            if (conn.State == ConnectionState.Closed) conn.Open();

            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT DISTINCT Discriminator FROM Transacoes WHERE ContaId = @id;";
            cmd.Parameters.Add(new SqliteParameter("@id", contaId));

            var tipos = new List<string>();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
                tipos.Add(reader.GetString(0));

            return tipos;
        }
    }
}
