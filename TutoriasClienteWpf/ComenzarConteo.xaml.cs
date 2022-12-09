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
using System.Windows.Threading;

namespace TutoriasClienteWpf
{
    /// <summary>
    /// Lógica de interacción para ComenzarConteo.xaml
    /// </summary>
    public partial class ComenzarConteo : Window
    {
        readonly DispatcherTimer timer = new();
        public ComenzarConteo()
        {
            InitializeComponent();
            btDetener.IsEnabled = false;
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += (s, e) =>
            {
                lbCronometro.Content = (int)lbCronometro.Content + 1;
            };
        }

        private void BtnComenzar(object sender, RoutedEventArgs e)
        {
            timer.Start();
            btDetener.IsEnabled = true;
            btComenzar.IsEnabled = false;
        }

        private void BtnDetener(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            CalificarTutoria calificarTutoria = new()
            {
                Owner = this
            };
            calificarTutoria.Show();
            Hide();
        }

        private void BtnCancelarConteo(object sender, RoutedEventArgs e)
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
