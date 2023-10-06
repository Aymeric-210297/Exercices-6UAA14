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

namespace _6TTI_WPFACT03_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MethodesDuProjet methodesDuProjet = new MethodesDuProjet();

        public MainWindow()
        {
            InitializeComponent();

            TxtA.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            TxtB.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);
            TxtC.PreviewTextInput += new TextCompositionEventHandler(VerifTextInput);

            BtnCalculer.Click += new RoutedEventHandler(ClickBouton);

            // Ne sert à rien
            BtnV.Background = Brushes.Red;
            BtnCalculer.MouseEnter += new MouseEventHandler(SurvolBouton);
            BtnCalculer.MouseLeave += new MouseEventHandler(SurvolBouton);
        }

        private bool EstEntier(string texte)
        {
            return int.TryParse(texte, out int _);
        }

        private void VerifTextInput(object sender, TextCompositionEventArgs e)
        {
            if (e.Text != "," && e.Text != "-" && !EstEntier(e.Text)) {
                e.Handled = true;
            } else if (e.Text == "," || e.Text == "-")
            {
                if (((TextBox)sender).Text.IndexOf(e.Text) > -1) {
                    e.Handled = true;
                }
            }
        }

        private void SurvolBouton(object sender, MouseEventArgs e)
        {
            if (BtnV.Visibility == Visibility.Hidden)
            {
                BtnV.Visibility = Visibility.Visible;
            }
            else
            {
               BtnV.Visibility = Visibility.Hidden;
            }
        }

        private void ClickBouton(object sender, RoutedEventArgs e)
        {
            double A;
            if (!VerifierInput("A", TxtA.Text, out A)) return;

            double B;
            if (!VerifierInput("B", TxtB.Text, out B)) return;

            double C;
            if (!VerifierInput("C",  TxtC.Text, out C)) return;

            MessageBox.Show(methodesDuProjet.ResoudreTrinome(A, B, C));
        }

        private bool VerifierInput(string arg, string input, out double resultat)
        {
            resultat = double.NaN;
            if (string.IsNullOrEmpty(input)) {
                MessageBox.Show("Il faut remplir " + arg);
                return false;
            } else
            {
                bool res = double.TryParse(input, out resultat);
                if (!res)
                {
                    MessageBox.Show("Le nombre " + arg + " n'est pas valide !");
                }
                return res;
            }
        }
    }
}
