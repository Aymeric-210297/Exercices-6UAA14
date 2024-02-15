using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _6TTI_WPFACT07_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer;
        Chien[] chiens = new Chien[4];
        Parieur[] parieurs = new Parieur[3];

        public MainWindow()
        {
            InitializeComponent();

            // Timer pour gérer la course
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(TimerTick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 40);

            // Check des entrées sur les inputs
            textBoxEcusPari.PreviewTextInput += new TextCompositionEventHandler(VerifierTextInputNombre);
            textBoxNumeroChienPari.PreviewTextInput += new TextCompositionEventHandler(VerifierTextInputNombre);

            // Évènements boutons
            buttonReset.Click += new RoutedEventHandler(Reset);
            buttonLancerCourse.Click += new RoutedEventHandler(LancerCourse);
            buttonMettrePari.Click += new RoutedEventHandler(MettrePari);

            // Création des parieurs
            parieurs[0] = new Parieur("Joe", 50, textBlockParieur1, radioButtonParieur1, textBlockParieurActuel);
            parieurs[1] = new Parieur("Bob", 75, textBlockParieur2, radioButtonParieur2, textBlockParieurActuel);
            parieurs[2] = new Parieur("Bill", 45, textBlockParieur3, radioButtonParieur3, textBlockParieurActuel);

            // Création des chiens
            chiens[0] = new Chien(1, canvasPiste);
            chiens[1] = new Chien(2, canvasPiste);
            chiens[2] = new Chien(3, canvasPiste);
            chiens[3] = new Chien(4, canvasPiste);
        }

        private void VerifierTextInputNombre(object sender, TextCompositionEventArgs e)
        {
            // Vérifier que l'entrée est bien un nombre entier.
            if (!int.TryParse(e.Text, out int _))
            {
                e.Handled = true;
            }
        }

        public void Reset(object sender, RoutedEventArgs e)
        {
            // Remplacer les anciens parieurs par des nouveaux pour réinitialiser le programme.
            parieurs[0] = new Parieur("Joe", 50, textBlockParieur1, radioButtonParieur1, textBlockParieurActuel);
            parieurs[1] = new Parieur("Bob", 75, textBlockParieur2, radioButtonParieur2, textBlockParieurActuel);
            parieurs[2] = new Parieur("Bill", 45, textBlockParieur3, radioButtonParieur3, textBlockParieurActuel);
        }

        private void MettrePari(object sender, RoutedEventArgs e)
        {
            // Vérifier que les entrées ne sont pas vides.
            if (textBoxEcusPari.Text.Length <= 0)
            {
                MessageBox.Show("Veuillez entrer un nombre d'écus à parier !");
                return;
            }
            if (textBoxNumeroChienPari.Text.Length <= 0)
            {
                MessageBox.Show("Veuillez entrer le numéro du chien sur lequel vous voulez parier !");
                return;
            }

            // Vérifier que le chien existe.
            int chienIndex = int.Parse(textBoxNumeroChienPari.Text) - 1;
            if (chienIndex >= chiens.Length || chienIndex < 0)
            {
                MessageBox.Show("Ce chien n'existe pas !");
                return;
            }

            // Trouver le parieur sélectionné et placer le pari.
            Parieur parieur = Array.Find(parieurs, parieur => parieur.RadioButton.IsChecked == true);
            if (!parieur.Parier(int.Parse(textBoxEcusPari.Text), chiens[chienIndex]))
            {
                return;
            };

            // Remettre l'état par défaut.
            textBoxEcusPari.Text = "5";
            textBoxNumeroChienPari.Text = "";
        }

        private void LancerCourse(object sender, RoutedEventArgs e)
        {
            // Chercher un parieur en mesure de parier mais qui n'a pas placé de pari.
            Parieur parieurSansPari = Array.Find(parieurs, parieur => parieur.Portefeuille >= 5 && parieur.PariActuel == null);
            if (parieurSansPari != null)
            {
                MessageBox.Show("Il est impossible de lancer la course tant que tous les parieurs en mesure de parier n'ont pas tous placé un pari.");
                return;
            }

            // Vérifier qu'il y a au moins 1 parieur.
            Parieur parieur = Array.Find(parieurs, parieur => parieur.PariActuel != null);
            if (parieur == null)
            {
                MessageBox.Show("Aucun parieur n'a placé de pari, impossible de commencer la course. Il faut remettre à zéro le programme !");
                return;
            }

            // Bloquer l'accès à la salle des paris le temps de la course.
            groupBoxSallePari.IsEnabled = false;
            // Commencer le timer de la course.
            dispatcherTimer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            // Chercher un chien qui n'a pas terminé la course, et s'il n'y en a pas alors stopper la course.
            if (Array.Find(chiens, chien => !chien.IsFinished) == null)
            {
                // Stopper le timer de la course.
                ((DispatcherTimer)sender).Stop();

                // Trouver le gagnant grace à l'opacité de son image (définie en fonction de sa place dans le classement).
                Chien winnerChien = Array.Find(chiens, chien => chien.Image.Opacity == 1);
                MessageBox.Show("Le chien numéro " + winnerChien.Numero + " a gagné.");

                // Réinitialiser les chiens à leur état initial.
                for (var i = 0; i < chiens.Length; i++)
                {
                    Chien chien = chiens[i];
                    chien.IsFinished = false;
                    chien.ResetImage();
                }

                // Calculer et distribuer les gains.
                string recap = "Récapitulatif:";
                int pertes = 0;
                List<Parieur> winners = new List<Parieur>();
                for (var i = 0; i < parieurs.Length; i++)
                {
                    Parieur parieur = parieurs[i];
                    if (parieur.PariActuel != null)
                    {
                        if (parieur.PariActuel.Chien == winnerChien)
                        {
                            winners.Add(parieur);
                            parieur.AjouterPortefeuille(parieur.PariActuel.Ecus * 2);
                            recap += $"\n- {parieur.Nom} a doublé sa mise ({parieur.PariActuel.Ecus})";
                        }
                        else
                        {
                            pertes += parieur.PariActuel.Ecus;
                        }
                        parieur.ResetPari();
                    }
                }

                // Redistribuer les pertes.
                if (winners.Count > 0)
                {
                    int gainParGagnant = pertes / winners.Count;
                    recap += "\n=> Les pertes accumulées sont de " + pertes + " écus, ";
                    if (winners.Count == 1)
                    {
                        recap += $"l'unique gagnant {winners[0].Nom} recevra {gainParGagnant} écus en plus.";
                    }
                    else
                    {
                        recap += "chaque gagnant recevra " + gainParGagnant + " écus en plus.";
                    }
                    for (var i = 0; i < winners.Count; i++)
                    {
                        winners[i].AjouterPortefeuille(gainParGagnant);
                    }
                }
                else
                {
                    recap += "\nAucun parieur n'a gagné :(";
                }

                MessageBox.Show(recap);

                // Ré-ouvrir la salle des paris pour la prochaine course.
                groupBoxSallePari.IsEnabled = true;

                // Il n'y a pas lieu de continuer donc on quitte la méthode.
                return;
            }

            Random rand = new Random();

            // Calculer le déplacement de chaque chien.
            for (int i = 0; i < chiens.Length; i++)
            {
                Chien chien = chiens[i];
                // Vérifier si il a fini la course, si oui alors on abandonne.
                if (!chien.IsFinished)
                {
                    // Récupérer l'image, effectuer une rotation aléatoire (effet de course peu réussi mais ça passe) et faire avancer l'image
                    Image imageChien = chien.Image;
                    RotateTransform rotateTransform = new RotateTransform(rand.Next(0, 20));
                    imageChien.RenderTransform = rotateTransform;
                    chien.FaireAvancer(rand.Next(1, 20));

                    //  Détecter si le chien à atteint la ligne d'arrivée en utilisant la hitbox invisible de la ligne d'arrivée.
                    if (Canvas.GetLeft(imageChien) >= Canvas.GetLeft(rectangleHitbox) - rectangleHitbox.Width)
                    {
                        // Changer l'image du chien par un trophée pour indiquer qu'il a fini la course.
                        BitmapImage bitmapImageTrophy = new BitmapImage();
                        bitmapImageTrophy.BeginInit();
                        bitmapImageTrophy.UriSource = new Uri("/assets/trophy-icon.png", UriKind.Relative);
                        bitmapImageTrophy.EndInit();
                        chien.Image.Source = bitmapImageTrophy;

                        // Changer l'opacité du chien en fonction de sa position dans le classement et indiquer que ce chien a fini la course.
                        chien.Image.Opacity = 1 / (double)chiens.Length * chiens.Count(chien => !chien.IsFinished);
                        chien.IsFinished = true;
                    }
                }
            }
        }
    }
}
