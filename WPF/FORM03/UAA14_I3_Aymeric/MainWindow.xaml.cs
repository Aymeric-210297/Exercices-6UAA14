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

namespace UAA14_I3_Aymeric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // btnCalculer, btnReset, inputNumber1, inputNumber2, inputOpAdd, inputOpMinus, resCalcul

            // Evenements inputs
            inputNumber1.PreviewTextInput += InputNumber_PreviewTextInput;
            inputNumber2.PreviewTextInput += InputNumber_PreviewTextInput;

            // Evenements boutons
            btnReset.Click += BtnReset_Click;
            btnCalculer.Click += BtnCalculer_Click;
        }

        // Evenement click du bouton calculer
        private void BtnCalculer_Click(object sender, RoutedEventArgs e)
        {
            // Vérifier que l'utilisateur à bien encoder les nombres, le reste des vérifications sont faites pendant que l'utilisateur encode les nombres
            if (inputNumber1.Text.Length == 0)
            {
                MessageBox.Show("Vous devez encoder le nombre 1 !");
                return;
            }

            if (inputNumber2.Text.Length == 0)
            {
                MessageBox.Show("Vous devez encoder le nombre 2 !");
                return;
            }

            MethodesDuProjet methodes = new MethodesDuProjet();

            // Préparer les inputs pour le calcul
            ushort[] inputNumber1Tab = methodes.RemplirTableau(inputNumber1.Text);
            ushort[] inputNumber2Tab = methodes.RemplirTableau(inputNumber2.Text);

            // Initaliser les variables du résultat
            ushort[] res;
            bool ok = false;

            if (inputOpAdd.IsChecked == true)
            {
                methodes.Additionne(inputNumber1Tab, inputNumber2Tab, out res, out ok);
            } else if (inputOpSubtract.IsChecked == true)
            {
                ok = methodes.Soustrait(inputNumber1Tab, inputNumber2Tab, out res);
            } else
            {
                MessageBox.Show("Il faut préciser une opération !");
                return;
            }

            // Affichage du résultat
            if (ok)
            {
                resCalcul.Text = methodes.Concatene(res);
            } else
            {
                resCalcul.Text = "Calcul impossible";
            }
        }

        // Evenement click du bouton reset
        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            // Remettre tout les contrôles à leur état initial
            resCalcul.Text = "";
            inputNumber1.Text = "";
            inputNumber2.Text = "";
            inputOpAdd.IsChecked = true;
            inputOpSubtract.IsChecked = false;
        }

        // Evenement qui permet de vérifier ce que l'utilisateur écrit
        private void InputNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifier si l'utilisateur encode 0 ou 1
            if (e.Text != "1" && e.Text != "0")
            {
                e.Handled = true; // Stopper la frappe
            }

            // Vérifier le nombre de caractères
            if (((TextBox) sender).Text.Length >= 7)
            {
                // Afficher une erreur et stopper la frappe
                MessageBox.Show("Vous ne pouvez pas encoder plus de 7 caractères !");
                e.Handled = true;
            }
        }
    }
}
