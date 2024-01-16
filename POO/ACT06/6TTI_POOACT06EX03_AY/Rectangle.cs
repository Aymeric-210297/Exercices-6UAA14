using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX03_AY
{
    internal class Rectangle : Forme
    {
        private double _tailleLongueur;
        private double _tailleLargeur;

        public double TailleLongueur
        {
            get { return _tailleLongueur; }
            set { _tailleLongueur = value; }
        }

        public double TailleLargeur
        {
            get { return _tailleLargeur; }
            set { _tailleLargeur = value; }
        }

        public Rectangle(double tailleLongueur, double tailleLargeur, string couleur)
        {
            _tailleLongueur = tailleLongueur;
            _tailleLargeur = tailleLargeur;
            _couleur = couleur;
        }

        public override double Perimetre()
        {
            return (_tailleLongueur * 2) + (_tailleLargeur * 2);
        }

        public override double Surface()
        {
            return _tailleLongueur * _tailleLargeur;
        }

        public override string Afficher()
        {
            return "Rectangle[tailleLongueur:" + _tailleLongueur + ";tailleLargeur:" + _tailleLargeur + ";couleur:" + _couleur + ";perimetre:" + Perimetre() + ";surface:" + Surface() + "]";
        }
    }
}
