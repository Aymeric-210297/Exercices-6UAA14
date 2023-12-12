namespace CeUAA14Partie2_dec23_Aymeric
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instancier mes méthodes
            MesMethodes mesMethodes = new MesMethodes();

            // Intro
            Console.WriteLine("Bienvenue dans ce jeu de tir ... Vous démarrez avec 30 balles");
            Console.WriteLine("=============================================================");

            // Création des objets
            Console.WriteLine("Quel est votre nom: ");
            string? pseudo = Console.ReadLine();
            if (pseudo.Length <= 0) pseudo = null;
            Joueur joueur = new Joueur(pseudo ?? "Anonymous");
            Console.WriteLine("Bonjour " + joueur.Pseudo);
            Console.WriteLine("\n");
            PaintBallGun gun = new PaintBallGun();

            // Boucle de jeu
            bool recom = true;
            while(recom)
            {
                Console.WriteLine("Vous avez un total de " + joueur.CompterBalles() + " balles (" + joueur.CompterChargeurs() + " chargeurs) dans votre poche et " + (gun.Chargeur?.NombreBalle ?? 0) + " balles dans le chargeur.");
                if ((gun.Chargeur?.NombreBalle ?? 0) <= 0)
                {
                    Console.WriteLine("Attention votre chargeur est vide !");
                }

                // Menu pour l'utilisateur
                Console.WriteLine("\n");
                Console.WriteLine("Espace pour tirer,");
                Console.WriteLine("r pour recharger,");
                Console.WriteLine("+ pour reprendre des munitions,");
                Console.WriteLine("q pour quitter");

                ConsoleKeyInfo input = Console.ReadKey();
                Console.WriteLine("\n");

                switch(input.Key)
                {
                    case ConsoleKey.Spacebar:
                        Resultat errorTirer = gun.Tirer();
                        if (errorTirer == Resultat.SUCCESS)
                        {
                            mesMethodes.WriteSuccess("=> Tir effectué");
                        } else
                        {
                            mesMethodes.WriteError("!> Tir non effectué : " + mesMethodes.TraduireErreur(errorTirer));
                        }
                        break;
                    case ConsoleKey.R:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("<Rechargement...>");
                        Console.ResetColor();

                        Thread.Sleep(1000);

                        Chargeur chargeur;
                        Resultat errorRecupererChargeur = joueur.RecupererChargeur(out chargeur);
                        if (errorRecupererChargeur != Resultat.SUCCESS)
                        {
                            mesMethodes.WriteError("!> Recharge non effectuée : " + mesMethodes.TraduireErreur(errorRecupererChargeur));
                        } else
                        {
                            Chargeur? oldChargeur;
                            Resultat errorRecharger = gun.Recharger(chargeur, out oldChargeur);
                            if (errorRecharger != Resultat.SUCCESS)
                            {
                                joueur.AjouterChargeur(chargeur);
                                mesMethodes.WriteError("!> Recharge non effectuée : " + mesMethodes.TraduireErreur(errorRecharger));
                            } else
                            {
                                mesMethodes.WriteSuccess("=> Recharge effectuée");
                                if (oldChargeur != null && oldChargeur.NombreBalle != 0)
                                {
                                    joueur.AjouterChargeur(oldChargeur);
                                }
                            }
                        }
                        break;
                    case ConsoleKey.OemPlus:
                    case ConsoleKey.Add:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("<Ravitaillement...>");
                        Console.ResetColor();

                        Thread.Sleep(2000);

                        // Ajout de 2 chargeurs contenant au total 30 balles
                        joueur.AjouterChargeur(new Chargeur());
                        joueur.AjouterChargeur(new Chargeur(14));
                        mesMethodes.WriteSuccess("=> Vous avez reçu 30 balles (16+14)");
                        break;
                    case ConsoleKey.Q:
                        recom = false;
                        mesMethodes.WriteSuccess("=> Merci d'avoir joué.");
                        break;
                    default:
                        mesMethodes.WriteError("!> Cette option n'existe pas !");
                        break;
                }
            }
        }
    }
}