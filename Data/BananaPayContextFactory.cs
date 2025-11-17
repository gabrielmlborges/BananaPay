using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.IO;

namespace BananaPay.Data
{
    public class BananaPayContextFactory : IDesignTimeDbContextFactory<BananaPayContext>
    {
        public BananaPayContext CreateDbContext(string[] args)
        {
            var path = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "BananaPay.db");

            var options = new DbContextOptionsBuilder<BananaPayContext>()
                .UseSqlite($"Data Source={path}")
                .Options;

            return new BananaPayContext(options);
        }
    }
}
