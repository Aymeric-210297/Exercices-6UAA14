using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX03_AY
{
    internal class Carre : Forme
    {
        private double _tailleCotes;

        public double TailleCotes
        {
            get { return _tailleCotes; }
            set { _tailleCotes = value; }
        }

        public Carre(double tailleCotes, string couleur)
        {
            _tailleCotes = tailleCotes;
            _couleur = couleur;
        }

        public override double Perimetre()
        {
            return 4 * _tailleCotes;
        }

        public override double Surface()
        {
            return _tailleCotes * _tailleCotes;
        }

        public override string Afficher()
        {
            return "Carre[tailleCotes:" + _tailleCotes + ";couleur:" + _couleur + ";perimetre:" + Perimetre() + ";surface:" + Surface() + "]";
        }
    }
}
