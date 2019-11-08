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

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (textBox.Text != "" && textBox.Text != "Fonctionnalité")
            {
                ((MainWindow)this.Owner).AddSelectedFeat(textBox.Text);
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Fonctionnalité non définie", "Erreur");
            }
        }
    }
}
