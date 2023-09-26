namespace I2P623_Aymeric
{
    internal class Program
    {
        static ConsoleColor[] couleursConsole = { ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Red };

        static void Main(string[] args)
        {
            // Initialisation des feux
            FeuSignalisation feuSignalisation1 = new FeuSignalisation("1001", 0, true);
            FeuSignalisation feuSignalisation2 = new FeuSignalisation("007", 2, true);

            // Afficher l'état des feux
            Console.WriteLine("Etat des feux :");
            Console.WriteLine("----------------------");
            AfficherAvecCouleur(feuSignalisation1);
            AfficherAvecCouleur(feuSignalisation2);
            
            // Tester le changement d'état
            Console.WriteLine("\nChangement d'état :");
            Console.WriteLine("----------------------");
            for (int i = 0; i < 5; i++)
            {
                feuSignalisation1.changerCouleur((feuSignalisation1.Couleur + 1) % 3);
                AfficherAvecCouleur(feuSignalisation1);
            }

            Console.WriteLine("\nFaire passer le " + feuSignalisation2.Id + " à l'orange :");
            feuSignalisation2.changerCouleur(1);
            AfficherAvecCouleur(feuSignalisation2);
            Console.WriteLine("----------------------");

            // Tester le clignotement des feux
            Console.WriteLine("\nFeu clignotant :");
            Console.WriteLine("----------------------");
            for (int i = 0; i < 7; i++)
            {
                feuSignalisation2.clignoter();
                AfficherAvecCouleur(feuSignalisation2);
            }
        }

        /// <summary>
        /// Afficher les caractéristiques d'un feu dans la console avec des couleurs
        /// </summary>
        /// <param name="feuSignalisation">Feu à afficher dans la console</param>
        static void AfficherAvecCouleur(FeuSignalisation feuSignalisation)
        {
            Console.ForegroundColor = couleursConsole[feuSignalisation.Couleur];
            Console.BackgroundColor = feuSignalisation.Allume ? ConsoleColor.DarkGray : ConsoleColor.Gray;
            Console.WriteLine(feuSignalisation.AfficherCaracteristiques());
            Console.ResetColor();
        }
    }
}