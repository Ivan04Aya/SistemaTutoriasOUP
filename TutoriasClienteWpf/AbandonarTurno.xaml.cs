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
    /// Lógica de interacción para CancelarTurno.xaml
    /// </summary>
    public partial class AbandonarTurno : Window
    {
        public AbandonarTurno()
        {
            InitializeComponent();
        }

        private void BtnAbandonar(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancelarAbandono(object sender, RoutedEventArgs e)
        {
            Menu menu = new()
            {
                Owner = this
            };
            menu.Show();
            Hide();
        }
    }
}
