namespace _6TTI_POOACT02_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-- POOACT02 --");

            Console.WriteLine("Exercice 1 : Le cercle");
            Console.WriteLine("Exercice 2 : Nombre complexe");
            Console.WriteLine("Exercice 3 : Sandwichs aléatoires");
            Console.WriteLine("Exercice 4 : Personne");

            string recommencer;

            do
            {
                int exercice = DemanderReel("Quel exercice voulez-vous (1-4) ?");

                switch (exercice)
                {
                    case 1:
                        Console.WriteLine("-- EX01 --");
                        double rayon = DemanderDouble("Quel rayon voulez-vous pour votre cercle ?");

                        Cercle cercle = new Cercle(rayon);

                        Console.WriteLine(cercle);

                        cercle.Rayon = rayon / 2;

                        Console.WriteLine("Avec un cercle de rayon diminué de moitié :");
                        Console.WriteLine("-------------------------------------------");

                        Console.WriteLine(cercle);
                        break;
                    case 2:
                        Console.WriteLine("-- EX02 --");
                        double reelle1 = DemanderDouble("Que vaut la partie réelle du complexe de départ ?");
                        double imaginaire1 = DemanderDouble("Que vaut la partie imaginaire du complexe de départ ?");

                        Complexe complexe1 = new Complexe(reelle1, imaginaire1);

                        Console.WriteLine("Le premier complexe : " + complexe1.AfficheComplexe() + " a pour module : " + complexe1.CalculeModule());

                        double reelle2 = DemanderDouble("Que vaut la partie réelle du second complexe ?");
                        double imaginaire2 = DemanderDouble("Que vaut la partie imaginaire du second complexe ?");

                        Complexe complexe2 = new Complexe(reelle2, imaginaire2);

                        Console.WriteLine("Le second complexe est : " + complexe2.AfficheComplexe());

                        complexe1.Ajoute(complexe2);

                        Console.WriteLine("Le premier complexe devient : " + complexe1.AfficheComplexe() + " après ajout du second.");

                        break;
                    case 3:
                        Console.WriteLine("-- EX03 --");
                        SandwichMaker sandwichMaker = new SandwichMaker();
                        Console.WriteLine(sandwichMaker.ComposeSandwich());
                        break;
                    case 4:
                        Console.WriteLine("-- EX04 --");
                        Console.WriteLine("Quel est le nom de la première personne ?");
                        string nom1 = Console.ReadLine();
                        double monnaie1 = DemanderDouble("Combien d'argent a la première personne ? ");
                        Console.WriteLine("Quel est le nom de la deuxième personne ?");
                        string nom2 = Console.ReadLine();
                        double monnaie2 = DemanderDouble("Combien d'argent a la deuxième personne ? ");

                        Personne personne1 = new Personne(nom1, monnaie1);
                        Personne personne2 = new Personne(nom2, monnaie2);

                        double transfer1 = DemanderDouble(personne1.Nom + " combien voulez-vous donner à " + personne2.Nom + " ?");

                        bool effect1 = personne1.RetirerMonnaie(transfer1);
                        if (effect1)
                        {
                            personne2.AjouterMonnaie(transfer1);
                            Console.WriteLine("Transaction effectuée");
                        } else
                        {
                            Console.WriteLine("La transaction n'a pas aboutie");
                        }

                        Console.WriteLine(personne1.Afficher());
                        Console.WriteLine(personne2.Afficher());

                        double transfer2 = DemanderDouble(personne2.Nom + " combien voulez-vous donner à " + personne1.Nom + " ?");

                        bool effect2 = personne2.RetirerMonnaie(transfer2);
                        if (effect2)
                        {
                            personne1.AjouterMonnaie(transfer2);
                            Console.WriteLine("Transaction effectuée");
                        }
                        else
                        {
                            Console.WriteLine("La transaction n'a pas aboutie");
                        }

                        Console.WriteLine(personne1.Afficher());
                        Console.WriteLine(personne2.Afficher());

                        Console.WriteLine("Voulez-vous ajouter de l'argent au porte monnaie de " + personne1.Nom + " (oui ou autre) ?");
                        string donner = Console.ReadLine();

                        if (donner == "oui")
                        {
                            double combien = DemanderDouble("Combien voulez-vous ajouter ?");

                            personne1.AjouterMonnaie(combien);

                            Console.WriteLine(personne1.Afficher());
                            Console.WriteLine(personne2.Afficher());
                        }
                        break;
                    default:
                        Console.WriteLine("Cet exercice n'existe pas !");
                        break;
                }

                Console.WriteLine("Voulez-vous recommencer (oui ou autre) ?");
                recommencer = Console.ReadLine();
            } while (recommencer == "oui");
        }

        static int DemanderReel(string message)
        {
            int entree;
            string? entreeUtil;

            do
            {
                Console.WriteLine(message);
                entreeUtil = Console.ReadLine();
            } while (!int.TryParse(entreeUtil, out entree));

            return entree;
        }

        static double DemanderDouble(string message)
        {
            double entree;
            string? entreeUtil;

            do
            {
                Console.WriteLine(message);
                entreeUtil = Console.ReadLine();
            } while (!double.TryParse(entreeUtil, out entree));

            return entree;
        }
    }
}