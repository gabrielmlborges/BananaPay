using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;
using BananaPay.Models;
using BananaPay.Data;
using BananaPay.Repository;
using BananaPay.View;
using BananaPay.Services;
using System.IO;        // ← Path
using Microsoft.EntityFrameworkCore; // ← UseSqlite

namespace BananaPay
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var services = new ServiceCollection();

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = Path.Combine(folder, "BananaPay.db");
            var conn   = $"Data Source={dbPath}";

            services.AddDbContext<BananaPayContext>(opt => opt.UseSqlite(conn));

            // Repository
            services.AddScoped<IContaRepository, ContaRepositorySqlite>();

            // Services
            services.AddScoped<ContaService>();

            // Janelas
            services.AddTransient<Login>();
            services.AddTransient<Cadastro>();

            ServiceProvider = services.BuildServiceProvider();

            // Abre a janela principal via DI
            var mainWindow = ServiceProvider.GetRequiredService<Login>();
            mainWindow.Show();
        }
    }

}
