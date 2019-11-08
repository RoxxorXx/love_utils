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

namespace WpfApp2
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        List<string> baseControls = new List<string>();
        List<string> searchControls = new List<string>();
        public string touch = "";
        public string func = "";

        public Window1()
        {
            InitializeComponent();
            
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789!\"#$&'()*+,-./:;<=>?@[\\]^_``";

            foreach (char c in alphabet)
            {
                baseControls.Add(char.ToString(c));
            }
            
            baseControls.Add("espace");

            //KeyPad 
            baseControls.Add("numpad 0");
            baseControls.Add("numpad 1");
            baseControls.Add("numpad 2");
            baseControls.Add("numpad 3");
            baseControls.Add("numpad 4");
            baseControls.Add("numpad 5");
            baseControls.Add("numpad 6");
            baseControls.Add("numpad 7");
            baseControls.Add("numpad 8");
            baseControls.Add("numpad 9");
            baseControls.Add("numpad .");
            baseControls.Add("numpad /");
            baseControls.Add("numpad *");
            baseControls.Add("numpad -");
            baseControls.Add("numpad +");
            baseControls.Add("numpad entrer");
            baseControls.Add("numpad ,");
            baseControls.Add("numpad =");

            //Naviguation
            baseControls.Add("haut");
            baseControls.Add("bas");
            baseControls.Add("gauche");
            baseControls.Add("droite");
            baseControls.Add("home");
            baseControls.Add("fin");
            baseControls.Add("pageHaut");
            baseControls.Add("pageBas");

            //Editing
            baseControls.Add("insert");
            baseControls.Add("retour arr.");
            baseControls.Add("tab");
            baseControls.Add("effac.");
            baseControls.Add("retour");
            baseControls.Add("suppr.");

            //Function
            for (int i = 1; i <= 18; i++)
            {
                baseControls.Add("f" + i);
            }

            //Modifiers
            baseControls.Add("verr. num");
            baseControls.Add("verr. maj");
            baseControls.Add("arrêt def.");
            baseControls.Add("shift gauche");
            baseControls.Add("shift droit");
            baseControls.Add("ctrl gauche");
            baseControls.Add("ctrl droit");
            baseControls.Add("alt gauche");
            baseControls.Add("alt droit");
            baseControls.Add("windows gauche");
            baseControls.Add("windows droit");
            baseControls.Add("mode");

            //Application
            baseControls.Add("www");
            baseControls.Add("mail");
            baseControls.Add("calculatrice");
            baseControls.Add("ordinateur");
            baseControls.Add("recherche");
            baseControls.Add("home");
            baseControls.Add("précédent");
            baseControls.Add("suivant");
            baseControls.Add("rafraîchir");
            baseControls.Add("marque-page");

            //Misc
            baseControls.Add("pause");
            baseControls.Add("echap");
            baseControls.Add("aide");
            baseControls.Add("impr. écran");
            baseControls.Add("système");
            baseControls.Add("menu");
            baseControls.Add("application");
            baseControls.Add("power");
            baseControls.Add("€");
            baseControls.Add("undo");

            //Mouse
            baseControls.Add("clic gauche");
            baseControls.Add("clic droit");
            baseControls.Add("scroll haut");
            baseControls.Add("scroll bas");
            baseControls.Add("bouton 4 (souris)");
            baseControls.Add("bouton 5 (souris)");

            listBox.ItemsSource = baseControls;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                searchControls.Clear();
                for (int i = 0; i < baseControls.Count; i++)
                {
                    if (textBox.Text != "")
                    {
                        if (baseControls[i].Contains(textBox.Text))
                        {
                            searchControls.Add(baseControls[i]);
                        }
                    }
                }

                if (textBox.Text != "")
                {
                    listBox.ItemsSource = null;
                    listBox.ItemsSource = searchControls;
                }
                else
                {
                    listBox.ItemsSource = null;
                    listBox.ItemsSource = baseControls;
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            searchControls.Clear();
            for (int i = 0; i < baseControls.Count; i++)
            {
                if (textBox.Text != "")
                {
                    if (baseControls[i].Contains(textBox.Text))
                    {
                        searchControls.Add(baseControls[i]);
                    }
                }
            }

            if (textBox.Text != "")
            {
                listBox.ItemsSource = null;
                listBox.ItemsSource = searchControls;
            }
            else
            {
                listBox.ItemsSource = null;
                listBox.ItemsSource = baseControls;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                if (fonctionBox.Text != "" && fonctionBox.Text != "Fonction")
                {
                    touch = (string)listBox.SelectedValue;
                    func = fonctionBox.Text;
                    ((MainWindow)this.Owner).AddSelected(touch, func);
                    this.Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Fonction de la touche non définie", "Erreur");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Touche non sélectionnée", "Erreur");
            }
        }
    }
}
