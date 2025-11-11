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
        b.Entity<Conta>()
            .HasIndex(c => c.CpfDono)
            .IsUnique();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}
