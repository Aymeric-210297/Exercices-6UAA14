using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT02_AY
{
    internal class Personne
    {
        private string _nom;
        private double _monnaie;

        public string Nom
        {
            get { return _nom; }
        }

        public double Monnaie
        {
            get { return _monnaie; }
            set { _monnaie = value; }
        }

        public Personne(string nom, double monnaie)
        {
            _nom = nom;
            _monnaie = monnaie;
        }

        public bool AjouterMonnaie(double monnaie)
        {
            _monnaie += monnaie;
            return true;
        }

        public bool RetirerMonnaie(double monnaie)
        {
            if (_monnaie < monnaie) return false;
            _monnaie -= monnaie;
            return true;
        }

        public string Afficher()
        {
            return _nom + " a " + _monnaie + " Euros dans son porte monnaie";
        }
    }
}
