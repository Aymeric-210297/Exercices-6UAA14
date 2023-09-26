using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace I2P623_Aymeric
{
    internal class FeuSignalisation
    {
        private string[] couleurs = { "Vert", "Orange", "Rouge" };

        // Caractéristiques
        private string _id; // identifiant qui permet de reconnaître le feu
        private int _couleur; // couleur actuelle du feu (0 = vert; 1 = orange; 2 = rouge)
        private bool _allume; // si le feu est allumé ou pas

        // Constructeur
        public FeuSignalisation(string id, int couleur, bool allume)
        {
            _id = id;
            _couleur = couleur;
            _allume = allume;
        }

        // Propriétés
        public string Id
        {
            get { return _id; }
        }

        public int Couleur
        {
            get { return _couleur; }
        }

        public bool Allume
        {
            get { return _allume; }
        }

        // Méthodes

        /// <summary>
        /// Changer la couleur du feu de signalisation
        /// </summary>
        /// <param name="couleur">La nouvelle couleur du feu</param>
        /// <returns>Vrai si la permutation a réussi</returns>
        public bool changerCouleur(int couleur)
        {
            _couleur = couleur;
            return true;
        }

        /// <summary>
        /// Faire clignoter le feu de signalisation
        /// </summary>
        /// <returns>Vrai si le clignotement a réussi</returns>
        public bool clignoter()
        {
            _allume = !_allume;
            return true;
        }

        /// <summary>
        /// Afficher les caractéristiques du feu
        /// </summary>
        /// <returns>Un string contenant les caracéristiques du feu</returns>
        public string AfficherCaracteristiques()
        {
            return "Le feu de signalisation " + _id + " est " + couleurs[_couleur] + " et est " + (_allume ? "allumé" : "éteint");
        }
    }
}
