using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT02_AY
{
    internal class Cercle
    {
        private double _rayon;

        public Cercle(double rayon)
        {
            _rayon = rayon;
        }

        public double Rayon
        {
            get { return _rayon; }
            set { _rayon = value; }
        }

        public double CalculerAire()
        {
            return Math.PI * Math.Pow(_rayon, 2);
        }

        public double CalculerPerimetre()
        {
            return 2 * Math.PI * _rayon;
        }

        public override string ToString()
        {
            double perimetre = Math.Round(CalculerPerimetre(), 2);
            double aire = Math.Round(CalculerPerimetre(), 2);
            return "Le cercle de rayon " + _rayon + " a un périmètre de " + perimetre + " et une aire de " + aire;
        }
    }
}
