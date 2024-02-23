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

namespace CE_UAA14WPF24_Aymeric
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Préparer l'interface

            groupBoxTaille.Visibility = Visibility.Hidden;
            textBlockFooter.Text = "Test WPF 6T 2024";

            // Ajouter les évènements

            textBoxNbrColonnes.PreviewTextInput += TextBoxNbr_PreviewTextInput;
            textBoxNbrLignes.PreviewTextInput += TextBoxNbr_PreviewTextInput;

            radioButtonSolitaire.Checked += RadioButton_Checked;
            radioButtonMarelle.Checked += RadioButton_Checked;
            radioButtonBandeLaterale.Checked += RadioButton_Checked;

            buttonValider.Click += ButtonValider_Click;
            buttonReset.Click += ButtonReset_Click;
        }

        /// <summary>
        /// Remplacer l'image du bouton quand on clique dessus
        /// </summary>
        private void ButtonDamierCercle_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le bouton qui a été cliqué
            Button button = (Button)sender;

            // Créer la nouvelle image du bouton
            BitmapImage imageBouton = new BitmapImage();
            imageBouton.BeginInit();
            imageBouton.UriSource = new Uri("assets/volvik.png", UriKind.Relative);
            imageBouton.EndInit();

            Image imBouton = new Image();
            imBouton.Source = imageBouton;
            imBouton.Stretch = Stretch.Fill;

            // Remplacer l'image
            button.Content = imBouton;
        }

        /// <summary>
        /// Changer la couleur de fond du bouton quand on clique dessus
        /// </summary>
        private void ButtonDamierX_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le bouton qui a été cliqué
            Button button = (Button)sender;

            button.Background = Brushes.Red;
        }

        /// <summary>
        /// Remettre à zéro le programme quand l'utilisateur clique sur le bouton Reset.
        /// </summary>
        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            SupprimerDamier();

            radioButtonSolitaire.IsChecked = false;
            radioButtonMarelle.IsChecked = false;
            radioButtonBandeLaterale.IsChecked = false;

            
            groupBoxTaille.Visibility = Visibility.Hidden;
            textBlockFooter.Text = "Test WPF 6T 2024";

            textBoxNbrColonnes.Text = string.Empty;
            textBoxNbrLignes.Text = string.Empty;
        }

        /// <summary>
        /// Permet de savoir si une cellule (définie par sa colonne et sa ligne) doit apparaitre dans une disposition donnée.
        /// </summary>
        /// <param name="disposition">Disposition à utiliser (solitaire; marelle; forme creuse)</param>
        /// <param name="column">Colonne de la cellule actuelle</param>
        /// <param name="row">Ligne de la cellule actuelle</param>
        /// <param name="nbrLignes">Nombre de lignes dans le damier</param>
        /// <param name="nbrColonnes">Nombre de colonnes dans le damier</param>
        /// <returns>Vrai si la cellule doit apparaitre</returns>
        static private bool Disposition(string disposition, int column, int row, int nbrLignes, int nbrColonnes)
        {
            if (disposition == "solitaire")
            {
                return (column >= 3 && column <= 5) || (row >= 3 && row <= 5);
            } else if (disposition == "marelle")
            {
                if (column == row || column == 6 - row || row == 3 || column == 3)
                {
                    return !(column == 3 && row == 3);
                }
                else
                {
                    return false;
                }
            } else if (disposition == "forme creuse")
            {
                return column == 0 || column == nbrColonnes - 1 || row == 0 || row == nbrLignes - 1;
            } else
            {
                return true;
            }
        }

        /// <summary>
        /// Permet de vérifier les entrées et créer le damier quand l'utilisateur clique sur le bouton Valider
        /// </summary>
        private void ButtonValider_Click(object sender, RoutedEventArgs e)
        {
            // Créer le damier en fonction de la disposition choisie par l'utilisateur

            if (radioButtonSolitaire.IsChecked == true)
            {
                CreerDamier(9, 9, "solitaire", true);
            } else if (radioButtonMarelle.IsChecked == true)
            {
                CreerDamier(7, 7, "marelle", true);
            } else if (radioButtonBandeLaterale.IsChecked == true)
            {
                int nbrColonnes;
                int nbrLignes;

                // Vérifier les entrées de l'utilisateur
                if (
                    textBoxNbrColonnes.Text.Trim().Length <= 0 ||
                    textBoxNbrLignes.Text.Trim().Length <= 0 ||
                    !int.TryParse(textBoxNbrColonnes.Text, out nbrColonnes) ||
                    nbrColonnes > 12 || nbrColonnes < 2 ||
                    !int.TryParse(textBoxNbrLignes.Text, out nbrLignes) ||
                    nbrLignes > 12 || nbrLignes < 2
                ) {
                    textBlockFooter.Text = "Veuillez encoder des dimensions valides comprises entre 1 et 12.";
                    return;
                }

                CreerDamier(nbrLignes, nbrColonnes, "forme creuse", false);
            } else
            {
                textBlockFooter.Text = "Veuillez choisir une disposition.";
                return;
            }

            // Aucune erreur ne s'est produite, le damier devrait être créé: remettre le texte du footer à zéro au cas où l'utilisateur avait produit des erreurs
            textBlockFooter.Text = "Test WPF 6T 2024";
        }

        /// <summary>
        /// Changer la visibilité du groupe qui permet de gérer les dimensions du damier en fonction de la disposition sélectionnée par l'utilisateur
        /// </summary>
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (radioButtonBandeLaterale.IsChecked == true)
            {
                groupBoxTaille.Visibility = Visibility.Visible;
            } else {
                groupBoxTaille.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Vérifier si le texte entré par l'utilisateur est bien un nombre entier
        /// </summary>
        private void TextBoxNbr_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out _))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Supprimer le damier
        /// </summary>
        private void SupprimerDamier()
        {
            // Supprimer les cellules
            gridMain.Children.Clear();

            // Supprimer les lignes et les colonnes
            gridMain.RowDefinitions.Clear();
            gridMain.ColumnDefinitions.Clear();
        }

        /// <summary>
        /// Créer ou remplacer le damier
        /// </summary>
        /// <param name="rows">Nombre de lignes</param>
        /// <param name="columns">Nombre de colonnes</param>
        private void CreerDamier(int rows, int columns, string disposition, bool image)
        {
            // Supprimer le damier existant au cas où il existe
            SupprimerDamier();

            // Ajouter les lignes
            for (int i = 0; i < rows; i++)
            {
                gridMain.RowDefinitions.Add(new RowDefinition());
            }

            // Ajouter les colonnes
            for (int i = 0; i < columns; i++)
            {
                gridMain.ColumnDefinitions.Add(new ColumnDefinition());
            }

            // Ajouter les boutons
            for (int column = 0; column < columns; column++)
            {
                for (int row = 0; row < rows; row++)
                {
                    if (Disposition(disposition, column, row, rows, columns))
                    {
                        Button button = CreerBouton(image);

                        // Ajouter le bouton dans le damier
                        Grid.SetColumn(button, column);
                        Grid.SetRow(button, row);
                        gridMain.Children.Add(button);
                    }
                }
            }
        }

        /// <summary>
        /// Créer un bouton
        /// </summary>
        /// <param name="image">Si vrai alors met un cercle rouge et ajoute l'évènement click sinon met juste un X en rouge</param>
        /// <returns>Le nouveau bouton</returns>
        private Button CreerBouton(bool image)
        {
            Button button = new Button();
            button.Background = Brushes.Khaki;

            if (image)
            {
                // Création de l'image
                BitmapImage imageBouton = new BitmapImage();
                imageBouton.BeginInit();
                imageBouton.UriSource = new Uri("assets/petitCercleRouge.png", UriKind.Relative);
                imageBouton.EndInit();
                Image imBouton = new Image();
                imBouton.Source = imageBouton;
                imBouton.Stretch = Stretch.Fill;

                // Ajout de l'image dans le bouton
                button.Content = imBouton;

                // Ajout de l'évènement click
                button.Click += ButtonDamierCercle_Click;
            } else
            {
                // Ajout du texte dans le bouton
                button.Content = "X";
                button.FontSize = 22;
                button.FontWeight = FontWeights.Bold;
                button.Foreground = Brushes.Red;

                button.Click += ButtonDamierX_Click;
            }

            return button;
        }
    }
}
