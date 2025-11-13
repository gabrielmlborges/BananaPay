using Microsoft.EntityFrameworkCore;
using BananaPay.Models;

namespace BananaPay.Data;

public class BananaPayContext : DbContext
{
    public DbSet<Conta> Contas { get; set; }
    public DbSet<Transacao> Transacoes { get; set; }

    public string DbPath { get; }

    public BananaPayContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "BananaPay.db");
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        // índice CPF
        b.Entity<Conta>()
            .HasIndex(c => c.CpfDono)
            .IsUnique();

        // TPH + discriminadores
        b.Entity<Transacao>()
            .UseTphMappingStrategy()
            .HasDiscriminator<string>("Tipo")
            .HasValue<Saque>("Saque")
            .HasValue<Deposito>("Deposito")
            .HasValue<Transferencia>("Transferencia");

        // FKs duplas da Transferencia
        b.Entity<Transferencia>()
            .HasOne(t => t.Conta)
            .WithMany()
            .HasForeignKey(t => t.ContaId)
            .OnDelete(DeleteBehavior.Restrict);

        b.Entity<Transferencia>()
            .HasOne(t => t.ContaDestino)
            .WithMany()
            .HasForeignKey(t => t.ContaDestinoId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
