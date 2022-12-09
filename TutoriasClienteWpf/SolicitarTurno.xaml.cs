using ServiceReferenceTutorias;
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

namespace TutoriasClienteWpf
{
    /// <summary>
    /// Lógica de interacción para SolicitarTurno.xaml
    /// </summary>
    public partial class SolicitarTurno : Window
    {
        public SolicitarTurno()
        {
            InitializeComponent();
        }

        private void BtnSolicitar(object sender, RoutedEventArgs e)
        {
            TutoriasServiceClient serviceClient = new();
            string asunto = tbAsunto.Text;

        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {
            Menu menu = new()
            {
                Owner = this
            };
            menu.Show();
            Hide();
        }

        private Boolean ValidarAsunto(string asunto)
        {
            bool isValid = true;
            if(asunto != "")
            {
                tbAsunto.BorderBrush = new SolidColorBrush(Colors.Red);
                isValid = false;
            }
            else
            {
                tbAsunto.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            return isValid;
        }

        private Boolean ValidarHora()
        {
            bool validarHora = false;
            if (cbHora.SelectedIndex != -1)
            {
                validarHora = true;
            }
            else
            {
                MessageBox.Show("Por favor seleciona una hora");
            }
            return validarHora;
        }
    }
}
