namespace _6TTI_POOACT03_AY
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Message de bienvenue et affichages des choix disponibles
            Console.WriteLine("Bienvenue dans cet échange d'éléphants");
            Console.WriteLine("Tapez :");
            Console.WriteLine("1 pour afficher les informations de Zazou,");
            Console.WriteLine("2 pour Titi,");
            Console.WriteLine("3 pour les échanger");
            Console.WriteLine("4 pour voir le transfert d'un message de Zazou à Titi");
            Console.WriteLine("5 pour réviser la notion de tableaux et l'appliquer à des objets");
            Console.WriteLine("6 pour quitter");

            // Variable de recommencement et boucle du programme
            bool recommencer = true;
            do
            {
                // Obtenir le choix de l'utilisateur
                int choix;
                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("Choix non valide");
                } else
                {
                    // Instancier les éléphants
                    Elephant zazou = new Elephant("Zazou", 82);
                    Elephant titi = new Elephant("Titi", 100);

                    switch (choix)
                    {
                        case 1:
                            Console.WriteLine(zazou.AfficheQuiJeSuis());
                            break;
                        case 2:
                            Console.WriteLine(titi.AfficheQuiJeSuis());
                            break;
                        case 3:
                            // Echanger zazou et titi
                            Elephant tampon = zazou;
                            zazou = titi;
                            titi = tampon;

                            Console.WriteLine("Zazou: ");
                            Console.WriteLine(zazou.AfficheQuiJeSuis());
                            Console.WriteLine("Titi: ");
                            Console.WriteLine(titi.AfficheQuiJeSuis());
                            break;
                        case 4:
                            zazou.EnvoieMessage("Coucou Titi !", titi);
                            break;
                        case 5:
                            // Création du tableau avec les éléphants
                            Elephant[] elephants = new Elephant[7];
                            elephants[0] = zazou;
                            elephants[1] = titi;
                            elephants[2] = new Elephant("Victor", 147);
                            elephants[3] = new Elephant("Alexandre", 10);
                            elephants[4] = new Elephant("Sefedin", 58);
                            elephants[5] = new Elephant("Louis", 96);
                            elephants[6] = new Elephant("Nathan", 69);

                            // Déterminer l'éléphants avec les + grandes oreilles
                            Elephant? max = null;
                            for (int i = 0; i < elephants.Length; i++)
                            {
                                Elephant elephant = elephants[i];
                                if (max == null || elephant.TailleOreilles > max.TailleOreilles)
                                {
                                    max = elephant;
                                }
                            }

                            // Vérifier que l'éléphant n'est pas null
                            if (max != null)
                            {
                                Console.WriteLine("L'éléphant qui a les plus grandes oreilles est " + max.Nom + " avec oreilles de " + max.TailleOreilles + "cm.");
                            }
                            break;
                        case 6:
                            recommencer = false;
                            break;
                        default:
                            Console.WriteLine("Choix inconnu");
                            break;
                    }
                }
            } while(recommencer);
        }
    }
}