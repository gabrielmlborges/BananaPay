using System.Windows;
using BananaPay.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BananaPay.View
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        private readonly IContaService _service;

        public Cadastro(IContaService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void BotaoIrLogin_Click(object sender, RoutedEventArgs e)
        {
            var login = App.ServiceProvider.GetRequiredService<Login>();
            login.Show();
            Close();
        }

        private void BotaoCadastrar_Click(object sender, RoutedEventArgs e)
        {
            string nome = CaixaNomeCadastro.Text;
            string cpf = CaixaCPFCadastro.Text;
            string senha = CaixaSenhaCadastro.Text;
            bool deuCerto = _service.CriarConta(nome, cpf, senha);
            if (deuCerto) {
                MessageBox.Show(
                        "Conta criada com sucesso!",
                        "Aviso",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            } else {
                MessageBox.Show(
                        "Erro ao tentar criar sua conta",
                        "Aviso",
                        MessageBoxButton.OK,
                        MessageBoxImage.Error);
            }

        }
    }
}
