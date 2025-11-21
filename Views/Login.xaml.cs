using BananaPay.View;
using System.Windows;
using BananaPay.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BananaPay
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IContaService _service;
        public Login(IContaService service)
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
            int? id = _service.VerificarLogin(cpf, senha);
            if (id.HasValue)
            {
                var ContaService = App.ServiceProvider.GetRequiredService<IContaService>();
                var tela = new TelaUsuario(ContaService, id);
                tela.Show();
                Close();
            } else
            {
                MessageBox.Show(
                        "CPF ou senha inválidos",
                        "Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);
            }
        }
    }
}
