using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX01_AY
{
    internal class Velo : Vehicule
    {
        private string _type;
        private bool _estElectrique;

        public string Type
        {
            get { return _type; }
        }

        public bool EstElectrique
        {
            get { return _estElectrique; }
        }

        public Velo(string type, bool estElectrique, string modele, string marque, string couleur, decimal prix)
        {
            _type = type;
            _estElectrique = estElectrique;
            _modele = modele;
            _marque = marque;
            _couleur = couleur;
            _prix = prix;
        }

        public override string Affiche()
        {
            return "Velo[type:" + _type + ";estElectrique:" + _estElectrique + ";modele:" + _modele + ";marque:" + _marque + ";couleur:" + _couleur + ";prix:" + _prix + "]";
        }
    }
}
