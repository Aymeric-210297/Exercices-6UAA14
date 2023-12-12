using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA14Partie2_dec23_Aymeric
{
    internal class Joueur
    {
        private string _pseudo;
        private List<Chargeur> _poche;
        public string Pseudo
        {
            get { return _pseudo; }
        }

        public Joueur(string pseudo)
        {
            _pseudo = pseudo;
            _poche = new List<Chargeur>();
            // Ajout des 30 balles sous la forme de 2 chargeurs car la capacité max d'un chargeur est de 16
            _poche.Add(new Chargeur());
            _poche.Add(new Chargeur(14));
        }

        /// <summary>
        /// Regrouper les chergeurs entre eux pour minimiser le nombre de chargeurs non plein dans l'inventaire du joueur.
        /// </summary>
        public void StackChargeurs()
        {
            int totalBalles = CompterBalles();
            int reste = totalBalles % 16;
            List<Chargeur> newPoche = new List<Chargeur>();
            for (int i = 0; i < totalBalles / 16; i++)
            {
                newPoche.Add(new Chargeur());
            }
            if (reste > 0)
            {
                newPoche.Add(new Chargeur(reste));
            }

            _poche = newPoche;
        }

        /// <summary>
        /// Récupérer un chargeur dans l'inventaire du joueur.
        /// </summary>
        /// <param name="chargeur">Chargeur du joueur</param>
        /// <returns>Le résultat de l'opération soit SUCCESS soit une erreur</returns>
        public Resultat RecupererChargeur(out Chargeur? chargeur)
        {
            chargeur = null;

            if (_poche.Count < 1)
            {
                return Resultat.E_AUCUN_CHARGEUR_JOUEUR;
            }

            StackChargeurs();

            chargeur = _poche.First();
            _poche.Remove(chargeur);

            return Resultat.SUCCESS;
        }

        /// <summary>
        /// Ajouter un chargeur dans l'inventaire du joueur.
        /// </summary>
        /// <param name="chargeur">Chargeur qu'il faut ajouter à son inventaire</param>
        public void AjouterChargeur(Chargeur chargeur)
        {
            _poche.Add(chargeur);
        }

        /// <summary>
        /// Compter les balles que le joueur possède dans son inventaire.
        /// </summary>
        /// <returns>Le nombre de balles du joueur</returns>
        public int CompterBalles()
        {
            int total = 0;
            for (int i = 0; i < _poche.Count; i++)
            {
                total += _poche[i].NombreBalle;
            }
            return total;
        }

        /// <summary>
        /// Compter les chargeurs que le joueur possède dans son inventaire.
        /// </summary>
        /// <returns>Le nombre de chargeurs du joueur</returns>
        public int CompterChargeurs()
        {
            return _poche.Count;
        }
    }
}
