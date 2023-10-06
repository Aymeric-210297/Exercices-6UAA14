using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace _6TTI_WPFACT02_AY
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
        TextBlock derniereTBClique; // on va l’utiliser pour faire une référence à la TextBlock sur laquelle on vient de cliquer
        bool trouvePaire = false;

        public MainWindow()
        {
            InitializeComponent();
            // Préparation du timer
            timer.Interval = TimeSpan.FromSeconds(.1);
            timer.Tick += new EventHandler(Timer_Tick);
            // Commencer le jeu
            SetUpGame();
        }

        /// <summary>
        /// Préparer le tableau pour une nouvelle partie
        /// </summary>
        private void SetUpGame()
        {
            List<string> animalEmoji = new List<string>()
            {
                "🐈","🐈",
                "🐷","🐷",
                "🐐","🐐",
                "🦊","🦊",
                "🐴","🐴",
                "🦉","🦉",
                "🐀","🐀",
                "🦅","🦅"
            }; // on initialise la liste à chaque fois pour remettre les émojis au cas où le joueur à cliqué sur rejouer

            tempsEcoule = 0;
            nbPairesTrouvees = 0;
            timer.Start();

            foreach (TextBlock textBlock in grdMain.Children.OfType<TextBlock>())
            {
                if (textBlock.Name != "txtTemps")
                {
                    textBlock.Visibility = Visibility.Visible; // on remet visible les textblock au cas où le joueur à cliqué sur rejouer
                    Random nbAlea = new Random();
                    int index = nbAlea.Next(animalEmoji.Count);
                    string nextEmoji = animalEmoji[index];
                    textBlock.Text = nextEmoji;
                    animalEmoji.RemoveAt(index); // on retire un animal de la liste pour ne pas l’attribuer à nouveau.
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
            if (nbPairesTrouvees == 8)
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
            if (nbPairesTrouvees == 8)
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
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
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
