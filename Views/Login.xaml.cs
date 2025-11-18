using BananaPay.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BananaPay.Data;
using BananaPay.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BananaPay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly ContaService _service;
        public Login(ContaService service)
        {
            InitializeComponent();
            _service = service;
        }

        private void IrCadastro_Click(object sender, RoutedEventArgs e)
        {
            var cadastro = App.ServiceProvider.GetRequiredService<Cadastro>();
            cadastro.Show();
            Close();
        }

        private void BotaoLogin_Click(object sender, RoutedEventArgs e)
        {
            string cpf = CaixaLoginCPF.Text;
            string senha = CaixaLoginSenha.Text;
            bool deuCerto = _service.VerificarLogin(cpf, senha);
            if (deuCerto)
            {
                MessageBox.Show(
                        "Login realizado",
                        "Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            } else
            {
                MessageBox.Show(
                        "Erro ao fazer login",
                        "Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
        }
    }
}
