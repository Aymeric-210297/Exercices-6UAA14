using ConsoleTable;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace _6TTI_POOBDDEX01_AY;
class Program
{
    static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        string connectionString =
            "server=" + configuration["MYSQL_HOST"] +
            ";database=" + configuration["MYSQL_DATABASE"] +
            ";port=" + configuration["MYSQL_PORT"] +
            ";uid=" + configuration["MYSQL_USERNAME"] +
            ";pwd=" + configuration["MYSQL_PASSWORD"];

        MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
        BienModel bienModel = new BienModel(mySqlConnection);

        MesMethodes mesMethodes = new MesMethodes();

        bool recom = true;
        while (recom)
        {
            mesMethodes.WriteTitle("Gestionnaire de biens");
            Console.WriteLine("[1] Afficher la liste des biens");
            Console.WriteLine("[2] Créer un nouveau bien");
            Console.WriteLine("[3] Modifier un bien");
            Console.WriteLine("[4] Supprimer un bien");
            Console.WriteLine("[5] Fermer le programme");
            Console.Write("\nQue voulez-vous faire ? ");

            ConsoleKeyInfo choixUtil = Console.ReadKey();
            switch (choixUtil.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Console.WriteLine("\n\nRécupération des biens...");
                    if (!bienModel.RefreshBiens())
                    {
                        mesMethodes.WriteSuccess("\n[-] Une erreur est survenue, impossible de récupérer les biens.");
                    }
                    else
                    {
                        mesMethodes.WriteTitle("1. Liste des biens");
                        Table biensTable = new Table();
                        biensTable.SetHeaders("#", "Nom", "Taille", "Prix", "Ville", "Chambres");
                        for (int i = 0; i < bienModel.DataSet.Tables[0].Rows.Count; i++)
                        {
                            DataRow dataRow = bienModel.DataSet.Tables[0].Rows[i];
                            biensTable.AddRow(
                                (i + 1).ToString(),
                                !dataRow.IsNull("nom") ? dataRow["nom"].ToString()! : "Aucun nom spécifié",
                                !dataRow.IsNull("taille") ? dataRow["taille"].ToString()! : "Aucune taille spécifiée",
                                !dataRow.IsNull("prix") ? dataRow["prix"].ToString()! : "Aucun prix spécifié",
                                !dataRow.IsNull("ville") ? dataRow["ville"].ToString()! : "Aucune ville spécifiée",
                                !dataRow.IsNull("chambres") ? dataRow["chambres"].ToString()! : "Aucun nombre de chambres spécifié"
                            );
                        }
                        Console.Write(biensTable.ToString());
                    }
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    mesMethodes.WriteTitle("2. Créer un nouveau bien");

                    string? nom = mesMethodes.DemanderStringUtilisateur($"Nom : ", null, true);
                    int? taille = mesMethodes.DemanderNombreUtilisateur("Taille : ", null, true, 0, null);
                    int? prix = mesMethodes.DemanderNombreUtilisateur("Prix : ", null, true, 0, null);
                    string? ville = mesMethodes.DemanderStringUtilisateur("Ville : ", null, true);
                    string? description = mesMethodes.DemanderStringUtilisateur("Description : ", null, true);
                    int? chambres = mesMethodes.DemanderNombreUtilisateur("Chambres : ", null, true, 0, null);

                    if (bienModel.AddBien(nom, taille, prix, ville, 1, description, chambres))
                    {
                        mesMethodes.WriteSuccess("\n[+] Votre bien a été enregistré avec succès.");
                    }
                    else
                    {
                        mesMethodes.WriteError("\n[-] Une erreur est survenue, impossible de créer un nouveau bien.");
                    }

                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Console.WriteLine("\n\nRécupération des biens...");
                    if (!bienModel.RefreshBiens())
                    {
                        mesMethodes.WriteError("\n[-] Une erreur est survenue, impossible de récupérer les biens.");
                    }
                    else
                    {
                        mesMethodes.WriteTitle("3. Modifier un bien");
                        for (int i = 0; i < bienModel.DataSet.Tables[0].Rows.Count; i++)
                        {
                            DataRow dataRow = bienModel.DataSet.Tables[0].Rows[i];
                            Console.WriteLine("[" + (i + 1) + "] " + dataRow["nom"]);
                        }
                        Console.Write("\n");
                        int choix = (int)mesMethodes.DemanderNombreUtilisateur("Quel bien souhaitez-vous modifier ? ", null, false, 1, bienModel.DataSet.Tables[0].Rows.Count)!;
                        DataRow dataRowChoix = bienModel.DataSet.Tables[0].Rows[choix - 1];
                        mesMethodes.WriteTitle("3. Modifier un bien");
                        Console.WriteLine("Vous êtes en train de modifier le bien : " + dataRowChoix["nom"] + "\n");
                        string? nomModif = mesMethodes.DemanderStringUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "nom"),
                            dataRowChoix.IsNull("nom") ? null : (string)dataRowChoix["nom"],
                            true
                        );
                        int? tailleModif = mesMethodes.DemanderNombreUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "taille"),
                            dataRowChoix.IsNull("taille") ? null : (int)dataRowChoix["taille"],
                            true, 0, null
                        );
                        int? prixModif = mesMethodes.DemanderNombreUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "prix"),
                            dataRowChoix.IsNull("prix") ? null : (int)dataRowChoix["prix"],
                            true, 0, null
                        );
                        string? villeModif = mesMethodes.DemanderStringUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "ville"),
                            dataRowChoix.IsNull("ville") ? null : (string)dataRowChoix["ville"],
                            true
                        );
                        string? descriptionModif = mesMethodes.DemanderStringUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "description"),
                            dataRowChoix.IsNull("description") ? null : (string)dataRowChoix["description"],
                            true
                        );
                        int? chambresModif = mesMethodes.DemanderNombreUtilisateur(
                            mesMethodes.GenerateQuestionString(dataRowChoix, "chambres"),
                            dataRowChoix.IsNull("chambres") ? null : (int)dataRowChoix["chambres"],
                            true, 0, null
                        );

                        if (bienModel.UpdateBien((int)dataRowChoix["bienId"], nomModif, tailleModif, prixModif, villeModif, 1, descriptionModif, chambresModif))
                        {
                            mesMethodes.WriteSuccess("\n[+] Votre bien a été modifié avec succès.");
                        }
                        else
                        {
                            mesMethodes.WriteError("\n[-] Une erreur est survenue, impossible de modifier un bien.");
                        }
                    }
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Console.WriteLine("\n\nRécupération des biens...");
                    if (!bienModel.RefreshBiens())
                    {
                        mesMethodes.WriteError("\n[-] Une erreur est survenue, impossible de récupérer les biens.");
                    }
                    else
                    {
                        mesMethodes.WriteTitle("4. Supprimer un bien");
                        for (int i = 0; i < bienModel.DataSet.Tables[0].Rows.Count; i++)
                        {
                            DataRow dataRow = bienModel.DataSet.Tables[0].Rows[i];
                            Console.WriteLine("[" + (i + 1) + "] " + dataRow["nom"]);
                        }

                        Console.Write("\n");
                        int choix = (int)mesMethodes.DemanderNombreUtilisateur("Quel bien souhaitez-vous supprimer ? ", null, false, 1, bienModel.DataSet.Tables[0].Rows.Count)!;
                        DataRow dataRowChoix = bienModel.DataSet.Tables[0].Rows[choix - 1];

                        if (bienModel.DeleteBien((int)dataRowChoix["bienId"]))
                        {
                            mesMethodes.WriteSuccess("\n[+] Votre bien a été supprimé avec succès.");
                        }
                        else
                        {
                            mesMethodes.WriteError("\n[-] Une erreur est survenue, impossible de supprimer un bien.");
                        }
                    }
                    break;
                case ConsoleKey.D5:
                case ConsoleKey.NumPad5:
                    recom = false;
                    break;
                default:
                    mesMethodes.WriteError("\n\n[-] Cette option n'existe pas.");
                    break;
            }

            if (recom)
            {
                Console.WriteLine("\n=> Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }
        }

        Console.Clear();
        mesMethodes.WriteSuccess("Merci d'avoir utilisé notre programme.");
    }
}
