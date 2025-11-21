using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using BananaPay.Models;
using BananaPay.Services;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
            attSaldo();
            atualizarGeral();
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
            atualizarGeral();

        }

        private void BotaoDeposito_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorDeposito.Text);
            _service.Depositar(val, _id);
            MessageBox.Show("Deposito realizado!");
            attSaldo();
            atualizarGeral();
        }

        private void BotaoTransferencia_Click(object sender, RoutedEventArgs e)
        {
            int val = int.Parse(ValorTransferir.Text);
            string destino = CPFTransferir.Text;

            _service.Transferir(val, _id, destino);
            MessageBox.Show("Transferência realizada!");
            attSaldo();
            atualizarGeral();
        }

        private void BotaoSair_Click(object sender, RoutedEventArgs e)
        {
            var login = App.ServiceProvider.GetRequiredService<Login>();
            login.Show();
            Close();
        }

        private void attS()
        {
            List<Saque> a = _service.atualizarSaques(_id);
            foreach(Saque s in a)
            {
                string linha = $"Saque de: {s.Valor:c} em {s.DataHora:g}";
                Historico.Items.Add(linha);
            }
        }

        private void attD()
        {
            List<Deposito> a = _service.atualizarDepositos(_id);
            foreach (Deposito s in a)
            {
                string linha = $"Deposito de: {s.Valor:c} em {s.DataHora:g}";
                Historico.Items.Add(linha);
            }
        }

        private void attT()
        {
            List<Transferencia> a = _service.atualizarTransferencias(_id);
            foreach (Transferencia s in a)
            {
                string linha = "";
                string destinatario = _service.PegarNomeDeDestino(s.ContaDestinoId);
                if (s.Valor < 0)
                {
                    
                    linha = $"Transferencia para: {destinatario} no valor {-1 * s.Valor:c} em {s.DataHora:g}";
                    
                } else
                {
                    linha = $"Transferencia recebida de {destinatario} no valor {s.Valor:c} em {s.DataHora:g}";
                }
                Historico.Items.Add(linha);

            }
        }

        private void atualizarGeral()
        {
            Historico.Items.Clear();
            attS();
            attD();
            attT();
        }
    }
}
