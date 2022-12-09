using ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using TutoriasClienteWpf.Modelo.Poco;

namespace TutoriasClienteWpf
{
    /// <summary>
    /// Lógica de interacción para ConsultarNotificaciones.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            ComprobarTurno();
        }

        private void BtnSolicitarTurno(object sender, RoutedEventArgs e)
        {
            SolicitarTurno solicitarTurno = new()
            {
                Owner = this
            };
            solicitarTurno.Show();
            Hide();
        }

        private void BtnComenzarConteo(object sender, RoutedEventArgs e)
        {
            ComenzarConteo comenzarConteo = new()
            {
                Owner = this
            };
            comenzarConteo.Show();
            Hide();
        }

        private void BtnAbandonarTurno(object sender, RoutedEventArgs e)
        {
            AbandonarTurno abandonarTurno = new()
            {
                Owner = this
            };
            abandonarTurno.Show();
            Hide();
        }

        private void BtnCerrarSesion(object sender, RoutedEventArgs e)
        {
            EstudianteModelo.Matricula = "";
            EstudianteModelo.Asunto = "";
            MainWindow mainWindow = new()
            {
                Owner = this
            };
            mainWindow.Show();
            Hide();
        }

        private async void ComprobarTurno()
        {
            TutoriasServiceClient serviceClient = new();
            Turno turno = await serviceClient.ConsultarTurnoAsync(EstudianteModelo.Matricula);
            if (turno == null)
            {
                lbFecha.Visibility = Visibility.Collapsed;
                lbHora.Visibility = Visibility.Collapsed;
                btComenzarConteo.IsEnabled = false;
                btAbandonarTurno.IsEnabled = false;
            }
            else
            {
                EstudianteModelo.Asunto = turno.asunto;
                DateTime dateTime = DateTime.Now;
                TimeSpan timeSpan = dateTime.TimeOfDay;
                if (turno.fechaTurno.ToShortDateString() == dateTime.ToShortDateString())
                {
                    if(turno.horaInicio > timeSpan && turno.horaFin < timeSpan)
                    {
                        lbFecha.Content = lbFecha.Content + " " + turno.fechaTurno.ToShortDateString();
                        lbHora.Content = lbHora.Content + " " + turno.horaInicio;
                        lbSituacionTutoria.Content = "Ya puedes entrar a tu tutoria";
                        btSolicitarTurno.IsEnabled = false;
                    }
                    else
                    {
                        lbFecha.Content = lbFecha.Content + " " + turno.fechaTurno.ToShortDateString();
                        lbHora.Content = lbHora.Content + " " + turno.horaInicio;
                        lbSituacionTutoria.Content = "Tu tutoria es hoy";
                        btSolicitarTurno.IsEnabled = false;
                        btComenzarConteo.IsEnabled = false;
                    }
                }
                else
                {
                    lbFecha.Content = lbFecha.Content + " " + turno.fechaTurno.ToShortDateString();
                    lbHora.Content = lbHora.Content + " " + turno.horaInicio;
                    lbSituacionTutoria.Content = "Tutoria en espera, matente atento";
                    btSolicitarTurno.IsEnabled = false;
                }
            }
        }
    }
}
