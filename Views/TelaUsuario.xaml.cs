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
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using BananaPay.Models;

namespace BananaPay.View
{
    /// <summary>
    /// Lógica interna para TelaUsuario.xaml
    /// </summary>
    public partial class TelaUsuario : Window
    {
        private readonly int? _id;
        private readonly ContaService _service;
        public ObservableCollection<Saque> aaa { get; set; }
        public TelaUsuario(ContaService service, int? id)
        {
            InitializeComponent();
            _service = service;
            _id = id;
            attSaldo();
            aaa = new ObservableCollection<Saque>();
            DataContext = this;
        }
        private void attSaldo()
        {
            ValorSaldo.Content = _service.AtualizarSaldo(_id);
        }

        private void BotaoSacar_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorSacar.Text);
            _service.Sacar(val, _id);
            MessageBox.Show("Saque realizado!");
            attSaldo();

        }

        private void BotaoDeposito_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorDeposito.Text);
            _service.Depositar(val, _id);
            MessageBox.Show("Deposito realizado!");
            attSaldo();

        }

        private void BotaoTransferencia_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorTransferir.Text);
            string destino = CPFTransferir.Text;

            _service.Transferir(val, _id, destino);
            MessageBox.Show("Transferência realizada!");
            attSaldo();
        }

        private void BotaoSair_Click(object sender, RoutedEventArgs e)
        {
            var login = App.ServiceProvider.GetRequiredService<Login>();
            login.Show();
            Close();
        }
    }
}
