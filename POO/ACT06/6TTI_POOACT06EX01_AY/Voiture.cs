using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX01_AY
{
    internal class Voiture : Vehicule
    {
        private string _motorisation;
        private bool _gps;

        public string Motorisation
        {
            get { return _motorisation; }
        }

        public bool Gps
        {
            get { return _gps; }
        }

        public Voiture(string motorisation, bool gps, string modele, string marque, string couleur, decimal prix)
        {
            _motorisation = motorisation;
            _gps = gps;
            _modele = modele;
            _marque = marque;
            _couleur = couleur;
            _prix = prix;
        }

        public override string Affiche()
        {
            return "Voiture[motorisation:" + _motorisation + ";gps:" + _gps + ";modele:" + _modele + ";marque:" + _marque + ";couleur:" + _couleur + ";prix:" + _prix + "]";
        }
    }
}
