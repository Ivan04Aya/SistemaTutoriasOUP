﻿using System;
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
    /// Lógica de interacción para CalificarTutoria.xaml
    /// </summary>
    public partial class CalificarTutoria : Window
    {
        public CalificarTutoria()
        {
            InitializeComponent();
        }

        private void BtnCalificar(object sender, RoutedEventArgs e)
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
