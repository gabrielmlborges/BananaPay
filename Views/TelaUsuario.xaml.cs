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
    /// Lógica interna para TelaUsuario.xaml
    /// </summary>
    public partial class TelaUsuario : Window
    {
        private readonly int? _id;
        private readonly ContaService _service;
        public TelaUsuario(ContaService service, int? id)
        {
            InitializeComponent();
            _service = service;
            _id = id;
        }

        private void BotaoSacar_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorSacar.Text);
            _service.Sacar(val, _id);
        }

        private void BotaoDeposito_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorDeposito.Text);
            _service.Depositar(val, _id);
        }

        private void BotaoTransferencia_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorTransferir.Text);
            string destino = CPFTransferir.Text;

            _service.Transferir(val, _id, destino);
        }
    }
}
