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

namespace _6TTI_WPFACT07_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            textBoxEcusPari.PreviewTextInput += new TextCompositionEventHandler(VerifierTextInputNombre);
            textBoxNumeroChienPari.PreviewTextInput += new TextCompositionEventHandler(VerifierTextInputNombre);

            Parieur joe = new Parieur("Joe", 50, textBlockParieur1, radioButtonParieur1, textBlockParieurActuel);
            Parieur bob = new Parieur("Bob", 75, textBlockParieur2, radioButtonParieur2, textBlockParieurActuel);
            Parieur bill = new Parieur("Bill", 45, textBlockParieur3, radioButtonParieur3, textBlockParieurActuel);
        }

        private void VerifierTextInputNombre(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int _))
            {
                e.Handled = true;
            }
        }
    }
}
