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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TutoriasClienteWpf.Modelo.Poco;

namespace TutoriasClienteWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbMatricula.Content = "";
            lbPassword.Content = "";
        }

        private async void BtnIniciarSesion(object sender, RoutedEventArgs e)
        {
            TutoriasServiceClient serviceClient = new();
            String matricula = tbMatricula.Text;
            String contrasena = pbContrasena.Password.ToString();
            bool validarCampos = ValidarCampos(matricula, contrasena);
            if(validarCampos)
            {
                bool respuesta = await serviceClient.IniciarSesionAsync(matricula, contrasena);
                if (serviceClient != null && respuesta)
                {
                    EstudianteModelo.Matricula = matricula;
                    Menu menu = new()
                    {
                        Owner = this
                    };
                    menu.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("La contraseña y/o matricula que ingreso son erroneos", "Credenciales erroneas");
                }
            }
        }

        private void BtnRegistrarUsuario(object sender, RoutedEventArgs e)
        {
            RegistrarUsuario registrarUsuario = new()
            {
                Owner = this
            };
            registrarUsuario.Show();
            Hide();
        }

        private Boolean ValidarCampos(string matricula, string contrasena)
        {
            bool resultado = true;
            if (matricula == "")
            {
                lbMatricula.Content = "Favor de ingresar la matricula";
                resultado = false;
            }
            else
            {
                lbMatricula.Content = "";
            }
            if(contrasena== "")
            {
                lbPassword.Content = "Favor de ingresar la contraseña";
                resultado=false;
            }
            else
            {
                lbPassword.Content = "";
            }
            return resultado;
        }
    }
}
