using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BananaPay.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BananaPay.View
{
    /// <summary>
    /// Lógica interna para Cadastro.xaml
    /// </summary>
    public partial class Cadastro : Window
    {
        private readonly ContaService _service;

        public Cadastro(ContaService service)
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
