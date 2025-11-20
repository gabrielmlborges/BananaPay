using Microsoft.EntityFrameworkCore;
using BananaPay.Models;

namespace BananaPay.Data;

public class BananaPayContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Saque> Transacoes { get; set; }
    public DbSet<Saque> Saques { get; set; }
    public DbSet<Deposito> Depositos { get; set; }
    public DbSet<Transferencia> Transferencias { get; set; }

    public BananaPayContext(DbContextOptions<BananaPayContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conta>()
            .HasIndex(c => c.CpfDono)
            .IsUnique();

        modelBuilder.Entity<Transacao>().ToTable("Transacoes");
        modelBuilder.Entity<Saque>().ToTable("Transacoes");
        modelBuilder.Entity<Deposito>().ToTable("Transacoes");
        modelBuilder.Entity<Transferencia>().ToTable("Transacoes");
    }
}
