using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA14Partie2_dec23_Aymeric
{
    internal struct MesMethodes
    {
        /// <summary>
        /// Traduire une erreur sous forme de texte pour afficher à l'utilisateur.
        /// </summary>
        /// <param name="error">L'erreur qu'il faut traduire</param>
        /// <returns>La traduction de l'erreur</returns>
        public string TraduireErreur(Resultat error)
        {
            switch (error)
            {
                case Resultat.E_AUCUN_CHARGEUR_ARME:
                    return "L'arme est vide ! Il faut recharger l'arme.";
                case Resultat.E_CHARGEUR_REMPLI:
                    return "Le chargeur de l'arme est déjà rempli !";
                case Resultat.E_AUCUN_CHARGEUR_JOUEUR:
                    return "Vous n'avez plus de chargeur pour recharger ! Ravitaillez-vous.";
                case Resultat.E_CHARGEUR_VIDE:
                    return "Votre chargeur est vide ! Il faut recharger l'arme.";
                case Resultat.E_PAS_BESOIN_CHARGER:
                    return "Recherger ne sert à rien car le chargeur est votre arme est plus grand que celui dans votre poche !";
                default:
                    return "Erreur inconnue";
            }
        }

        /// <summary>
        /// Ecrire dans la console un message de réussite.
        /// </summary>
        /// <param name="msg">Le message à afficher</param>
        public void WriteSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        /// <summary>
        /// Ecrire dans la console un message d'erreur.
        /// </summary>
        /// <param name="msg">Le message à afficher</param>
        public void WriteError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}
