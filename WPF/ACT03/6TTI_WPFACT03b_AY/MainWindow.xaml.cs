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

namespace _6TTI_WPFACT03b_AY
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnDuree.Click += new RoutedEventHandler(ClickBtnDuree);
            btnCalculer.Click += new RoutedEventHandler(ClickBtnResultat);
            btnInit.Click += new RoutedEventHandler(ClickBtnInit);

            btnInit.IsEnabled = false;
            progressInit.Visibility = Visibility.Hidden;
        }

        private bool CheckDate(out TimeSpan diff, out DateTime dateTimeArrivee, out DateTime dateTimeSortie)
        {
            diff = new TimeSpan();
            dateTimeArrivee = new DateTime();
            dateTimeSortie = new DateTime();

            if (boxDateArrivee.Text.Length <= 0)
            {
                MessageBox.Show("Il faut remplir la date d'arrivée !");
                return false;
            }
            if (boxDateSortie.Text.Length <= 0)
            {
                MessageBox.Show("Il faut remplir la date de sortie !");
                return false;
            }

            if (!DateTime.TryParse(boxDateArrivee.Text, out dateTimeArrivee))
            {
                MessageBox.Show("Date d'arrivée non valide !");
                return false;
            }

            if (!DateTime.TryParse(boxDateSortie.Text, out dateTimeSortie))
            {
                MessageBox.Show("Date de sortie non valide !");
                return false;
            }

            if (DateTime.Now > dateTimeArrivee)
            {
                MessageBox.Show("La date d'arrivée doit se trouver dans le futur !");
                return false;
            }

            if (dateTimeArrivee > dateTimeSortie)
            {
                MessageBox.Show("La date de sortie doit être après la date d'arrivée !");
                return false;
            }

            if ((dateTimeArrivee.Month == 12 || dateTimeArrivee.Month == 1 || dateTimeArrivee.Month == 4 || dateTimeArrivee.Month == 7 || dateTimeArrivee.Month == 8) && (dateTimeSortie.Month == 12 || dateTimeSortie.Month == 1 || dateTimeSortie.Month == 4 || dateTimeSortie.Month == 7 || dateTimeSortie.Month == 8))
            {
                diff = dateTimeSortie - dateTimeArrivee;

                if (diff.TotalDays > 60)
                {
                    MessageBox.Show("La durée de votre séjour est trop longue, maximum 2 mois !");
                    return false;
                }

                if (diff.TotalDays <= 1)
                {
                    MessageBox.Show("La durée de votre séjour est trop courte, minimum 2 jours !");
                    return false;
                }

                return true;
            }
            else
            {
                MessageBox.Show("Nous n'acceptons pas de venue durant les mois que vous avez indiqué !");
                return false;
            }
        }

        private void ClickBtnDuree(object sender, RoutedEventArgs e)
        {
            TimeSpan diff;
            DateTime dateTimeArrivee;
            DateTime dateTimeSortie;
            if (CheckDate(out diff, out dateTimeArrivee, out dateTimeSortie))
            {
                double nbrSemaines = diff.TotalDays / 7;
                if (nbrSemaines < 1)
                {
                    nbrSemaines = 1;
                }
                txtNbrSemaines.Text = Math.Round(nbrSemaines).ToString() + " semaines";
            }
        }

        private void ClickBtnResultat(object sender, RoutedEventArgs e)
        {
            TimeSpan diff;
            DateTime dateTimeArrivee;
            DateTime dateTimeSortie;
            if (!CheckDate(out diff, out dateTimeArrivee, out dateTimeSortie))
            {
                return;
            }
            if (boxNbrPersonnes.Text.Length <= 0)
            {
                MessageBox.Show("Il faut remplir le nombre de personne !");
                return;
            }

            int nbrPersonnes;
            if (!int.TryParse(boxNbrPersonnes.Text, out nbrPersonnes))
            {
                MessageBox.Show("Nombre de personne non valide !");
                return;
            }

            if (nbrPersonnes <= 0 || nbrPersonnes > 6)
            {
                MessageBox.Show("Le nombre de personne doit être entre 1 et 6 !");
                return;
            }

            if (radioChalet.IsChecked == false && radioTente.IsChecked == false) {
                MessageBox.Show("Vous devez sélectionner un type de logement !");
                return;
            }

            double prix = 0;

            if (dateTimeArrivee.Month == 7 || dateTimeArrivee.Month == 8)
            {
                if (radioChalet.IsChecked == true)
                {
                    if (nbrPersonnes <= 4)
                    {
                        prix = 547;
                    } else if (nbrPersonnes == 5) {
                        prix = 581;
                    } else if (nbrPersonnes == 6)
                    {
                        prix = 599;
                    }
                } else
                {
                    if (nbrPersonnes <= 4)
                    {
                        prix = 349;
                    }
                    else if (nbrPersonnes == 5)
                    {
                        prix = 380;
                    }
                    else if (nbrPersonnes == 6)
                    {
                        prix = 390;
                    }
                }
            } else
            {
                if (radioChalet.IsChecked == true)
                {
                    if (nbrPersonnes <= 4)
                    {
                        prix = 297;
                    }
                    else if (nbrPersonnes == 5)
                    {
                        prix = 330;
                    }
                    else if (nbrPersonnes == 6)
                    {
                        prix = 347;
                    }
                }
                else
                {
                    if (nbrPersonnes <= 4)
                    {
                        prix = 198;
                    }
                    else if (nbrPersonnes == 5)
                    {
                        prix = 220;
                    }
                    else if (nbrPersonnes == 6)
                    {
                        prix = 250;
                    }
                }
            }

            double nbrSemaines = diff.TotalDays / 7;

            if (nbrSemaines < 1)
            {
                nbrSemaines = 1;
            }

            resSemaines.Text = Math.Round(nbrSemaines).ToString();

            prix = prix * nbrSemaines;

            if (nbrSemaines >= 3)
            {
                prix = prix - (0.05 * prix);
            } else if (nbrSemaines >= 5)
            {
                prix = prix - (0.1 * prix);
            }

            if (checkReservation.IsChecked == true)
            {
                prix = prix + 12;
            }

            prix = prix + (0.30 * nbrPersonnes * diff.TotalDays);

            resPrix.Text = Math.Round(prix) + "€";

            btnInit.IsEnabled = true;
        }

        public async void ClickBtnInit(object sender, RoutedEventArgs e)
        {
            btnInit.IsEnabled = false;
            window.IsEnabled = false;
            progressInit.Visibility = Visibility.Visible;

            for (int i = 0; i <= 100; i++)
            {
                progressInit.Value = i;
                await Task.Delay(10);
            }

            MessageBox.Show("Votre demande à bien été envoyé.");
            window.Close();
        }
    }
}
