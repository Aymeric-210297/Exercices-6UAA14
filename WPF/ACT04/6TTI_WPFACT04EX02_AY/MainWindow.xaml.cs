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
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace _6TTI_WPFACT04EX02_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Timer
        DispatcherTimer timer = new DispatcherTimer();
        int tempsEcoule = 0;
        int nbPairesTrouvees = 0;

        // Fonctionnement du jeu
        int paires;
        TextBlock derniereTBClique; // on va l’utiliser pour faire une référence à la TextBlock sur laquelle on vient de cliquer
        TextBlock txtTemps;
        bool trouvePaire = false;

        public MainWindow()
        {
            InitializeComponent();
            // Préparer l'interface utilisateur
            txtTemps = SetUpElements();
            // Préparation du timer
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += new EventHandler(Timer_Tick);
            // Commencer le jeu
            SetUpGame();
        }

        /// <summary>
        /// Préparer l'interface utilisateur
        /// </summary>
        private TextBlock SetUpElements()
        {
            string pairesUtil;
            do
            {
                pairesUtil = Microsoft.VisualBasic.Interaction.InputBox("Combien de paires ?", "Configuration", "10");
            } while (!int.TryParse(pairesUtil, out paires) || paires > 12 || paires < 1);

            // Structure de la grille
            ColumnDefinition coldef1 = new ColumnDefinition();
            ColumnDefinition coldef2 = new ColumnDefinition();
            ColumnDefinition coldef3 = new ColumnDefinition();
            ColumnDefinition coldef4 = new ColumnDefinition();
            grdMain.ColumnDefinitions.Add(coldef1);
            grdMain.ColumnDefinitions.Add(coldef2);
            grdMain.ColumnDefinitions.Add(coldef3);
            grdMain.ColumnDefinitions.Add(coldef4);
            /*RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();
            RowDefinition rowDef4 = new RowDefinition();
            RowDefinition rowDef5 = new RowDefinition();
            grdMain.RowDefinitions.Add(rowDef1);
            grdMain.RowDefinitions.Add(rowDef2);
            grdMain.RowDefinitions.Add(rowDef3);
            grdMain.RowDefinitions.Add(rowDef4);
            grdMain.RowDefinitions.Add(rowDef5);*/
            for (int i = 0; i < Math.Ceiling(decimal.Divide(paires * 2, 4)); i++)
            {
                RowDefinition rowDefI = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDefI);
            }


            RowDefinition rowDef = new RowDefinition();
            grdMain.RowDefinitions.Add(rowDef);

            // Création des textblocks
            for (int i = 0; i < grdMain.ColumnDefinitions.Count; i++)
            {
                for (int j = 0; j < grdMain.RowDefinitions.Count - 1; j++)
                {
                    // Création du textblock
                    TextBlock txt = new TextBlock();
                    txt.HorizontalAlignment = HorizontalAlignment.Center;
                    txt.VerticalAlignment = VerticalAlignment.Center;
                    txt.FontSize = 36;
                    txt.MouseDown += Txt_MouseDown;

                    // Ajout dans la grille
                    Grid.SetColumn(txt, i);
                    Grid.SetRow(txt, j);
                    grdMain.Children.Add(txt);
                }
            }

            // Création du textblock pour le temps
            TextBlock txtTemps = new TextBlock();
            txtTemps.FontSize = 36;
            txtTemps.HorizontalAlignment = HorizontalAlignment.Center;
            txtTemps.VerticalAlignment = VerticalAlignment.Center;
            txtTemps.MouseDown += txtTemps_MouseDown;

            // Ajout dans la grille
            Grid.SetRow(txtTemps, grdMain.RowDefinitions.Count);
            Grid.SetRowSpan(txtTemps, grdMain.RowDefinitions.Count);
            Grid.SetColumnSpan(txtTemps, grdMain.ColumnDefinitions.Count);
            grdMain.Children.Add(txtTemps);

            return txtTemps;
        }

        /// <summary>
        /// Préparer le tableau pour une nouvelle partie
        /// </summary>
        private void SetUpGame()
        {
            string[] emojies = new string[12] {
                "🐈",
                "🐷",
                "🐐",
                "🦊",
                "🐴",
                "🦉",
                "🐀",
                "🦅",
                "🐘",
                "🦖",
                "🐋",
                "🦏"
            };

            // On initialise la liste à chaque fois pour remettre les émojis au cas où le joueur à cliqué sur rejouer
            List<string> pairesEmoji = new List<string>();
            for (int i = 0; i < paires; i++)
            {
                pairesEmoji.Add(emojies[i]);
                pairesEmoji.Add(emojies[i]);
            }

            tempsEcoule = 0;
            nbPairesTrouvees = 0;
            timer.Start();

            foreach (TextBlock textBlock in grdMain.Children.OfType<TextBlock>())
            {
                if (textBlock != txtTemps && pairesEmoji.Count > 0)
                {
                    textBlock.Visibility = Visibility.Visible; // on remet visible les textblock au cas où le joueur à cliqué sur rejouer
                    Random nbAlea = new Random();
                    int index = nbAlea.Next(pairesEmoji.Count);
                    string nextEmoji = pairesEmoji[index];
                    textBlock.Text = nextEmoji;
                    pairesEmoji.RemoveAt(index); // on retire un animal de la liste pour ne pas l’attribuer à nouveau.
                }
            }

        }

        /// <summary>
        /// Evenement qui permet de recommencer le jeu en cliquant sur le texte du timer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtTemps_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Confirmer que l'utilisateur à bien tout trouver avant de relancer le jeu.
            if (nbPairesTrouvees == paires)
            {
                SetUpGame();
            }
        }

        /// <summary>
        /// Evenement qui permet d'incrémenter le timer, d'afficher le timer et de stopper la partie une fois qu'elle est finie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            tempsEcoule++;
            txtTemps.Text = (tempsEcoule / 10F).ToString("0.0s");
            // Arrêter le jeu si toutes les paires sont trouvées.
            if (nbPairesTrouvees == paires)
            {
                timer.Stop();
                txtTemps.Text = txtTemps.Text + " - Rejouer ? ";
            }
        }

        /// <summary>
        /// Evenement qui permet de gérer le clique sur les émojis et de déterminer si le joueur à trouver la paire ou pas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlockActif = sender as TextBlock;
            if (!trouvePaire)
            {
                textBlockActif.Visibility = Visibility.Hidden;
                derniereTBClique = textBlockActif;
                trouvePaire = true;
            }
            else if (textBlockActif.Text == derniereTBClique.Text)
            {
                nbPairesTrouvees++;
                textBlockActif.Visibility = Visibility.Hidden;
                trouvePaire = false;
            }
            else
            {
                derniereTBClique.Visibility = Visibility.Visible;
                trouvePaire = false;
            }
        }
    }
}
