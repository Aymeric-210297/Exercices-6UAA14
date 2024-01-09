using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX01_AY
{
    internal abstract class Vehicule
    {
        protected string _modele;
        protected string _marque;
        protected string _couleur;
        protected decimal _prix;
        public string Modele {
            get { return _modele; }
        }
        public string Marque {
            get { return _marque; }
        }
        public string Couleur {
            get { return _couleur; }
            set { _couleur = value; }
        }
        public decimal Prix {
            get { return _prix; }
            set { _prix = value; }
        }

        public abstract string Affiche();
    }
}
