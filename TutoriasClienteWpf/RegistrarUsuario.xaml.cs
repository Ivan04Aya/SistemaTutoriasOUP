using ServiceReferenceTutorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Lógica de interacción para RegistrarUsuario.xaml
    /// </summary>
    public partial class RegistrarUsuario : Window
    {
        public RegistrarUsuario()
        {
            InitializeComponent();
            tbMatricula.MaxLength = 10;
            CargarComboTutor();
        }

        private async void BtnRegistrarUsuario(object sender, RoutedEventArgs e)
        {
            TutoriasServiceClient serviceClient = new();
            string nombre = tbNombre.Text;
            string apellidos = tbApellidos.Text;
            string matricula = tbMatricula.Text;
            string correo = tbCorreo.Text;
            string contrasena = pbContrasena.Password.ToString();
            bool validarTutor = ValidarTutor();
            bool validarCampos = ValidarCampos(nombre, apellidos, matricula, correo, contrasena);
            bool validarCorreo = ValidarCorreoElectronico(correo);
            if (validarTutor && validarCampos && validarCorreo)
            {
                Estudiante estudiante = SetEstudiante(nombre, apellidos, matricula, correo, contrasena);
                bool respuesta = await serviceClient.RegistrarEstudianteAsync(estudiante);
                if (respuesta)
                {
                    MessageBox.Show("El usuario ingresado se ha registrado correctamente", "Registro con éxito");
                    MainWindow mainWindow = new()
                    {
                        Owner = this
                    };
                    mainWindow.Show();
                }
                else
                {
                    MessageBox.Show("Error al registrar el nuevo usuario, intentelo nuevamente", "Error al registrar");
                }
            }

        }

        private void BtnCancelar(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new()
            {
                Owner = this
            };
            mainWindow.Show();
            Hide();
        }

        private async void CargarComboTutor()
        {
            TutoriasServiceClient serviceClient = new();
            Tutor[] nombresTutores;
            if (serviceClient != null)
            {
                List<String> tutors = new();
                nombresTutores = await serviceClient.ConsultarListaTutoresAsync();
                if (nombresTutores != null)
                {
                    for (int i = 0; i < nombresTutores.Length; i++)
                    {
                        tutors.Add(nombresTutores[i].nombre+" " + nombresTutores[i].apellidos);
                    }
                }
                cbTutor.ItemsSource = tutors;
            }
        }

        private static bool ValidarCorreoElectronico(string correo)
        {
            bool validarCorreo;
            Regex validateEmailRegex = new("^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$");
            if (validateEmailRegex.IsMatch(correo) == false)
            {
                MessageBox.Show("El correo electrónico no es valido, intentelo nuevamente.", "Correo electrónico invalido");
                validarCorreo = false;
            }
            else
            {
                validarCorreo = true;
            }
            return validarCorreo;
        }

        private bool ValidarTutor()
        {
            bool validarTutor = false;
            if (cbTutor.SelectedIndex != -1)
            {
                validarTutor = true;
            }
            else
            {
                MessageBox.Show("Por favor seleciona su tutor");
            }
            return validarTutor;
        }

        private bool ValidarCampos(string nombre, string apellidos,string matricula, string correo,string contraseña)
        {
            bool validarCampos = true;
            if(nombre == "")
            {
                tbNombre.BorderBrush = Brushes.Red;
                validarCampos = false;
            }
            else
            {
                tbNombre.BorderBrush = Brushes.Gray;
            }
            if(apellidos == "")
            {
                tbApellidos.BorderBrush = Brushes.Red;
                validarCampos = false;
            }
            else
            {
                tbNombre.BorderBrush = Brushes.Gray;
            }
            if(matricula == "")
            {
                tbMatricula.BorderBrush = Brushes.Red;
                validarCampos = false;
            }
            else
            {
                tbMatricula.BorderBrush = Brushes.Gray;
            }
            if(correo == "")
            {
                tbCorreo.BorderBrush = Brushes.Red;
                validarCampos = false;
            }
            else
            {
                tbCorreo.BorderBrush = Brushes.Gray;
            }
            if(contraseña == "")
            {
                pbContrasena.BorderBrush = Brushes.Red;
                validarCampos = false;
            }
            else
            {
                pbContrasena.BorderBrush = Brushes.Gray;
            }
            return validarCampos;
        }

        private Estudiante SetEstudiante(string nombre,string apellidos,string matricula,string correo,string contrasena)
        {
            Estudiante estudiante = new()
            {
                nombre = nombre,
                apellidos = apellidos,
                matricula = matricula,
                correo = correo,
                contrasena = contrasena,
                nombreTutor = (String)cbTutor.SelectedItem
            };
            return estudiante;
        }
    }
}
