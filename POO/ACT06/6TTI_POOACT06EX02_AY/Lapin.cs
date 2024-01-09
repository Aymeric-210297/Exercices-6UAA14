using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX02_AY
{
    internal class Lapin : Animal
    {
        private double _tailleOreilles;

        public double TailleOreilles
        {
            get { return _tailleOreilles; }
            set { _tailleOreilles = value; }
        }


        public Lapin(string nom, string dateDeNaissance, string numeroDePuce, double taille, bool estAnimalDeConcours, double tailleOreilles)
        {
            _nom = nom;
            _dateDeNaissance = dateDeNaissance;
            _numeroDePuce = numeroDePuce;
            _taille = taille;
            _estAnimalDeConcours = estAnimalDeConcours;
            _tailleOreilles = tailleOreilles;
        }

        public override bool Manger()
        {
            Console.WriteLine(_nom + " vient de manger sa carotte.");
            return true;
        }

        public bool FaireBond()
        {
            Console.WriteLine(_nom + " vient de faire un bond.");
            return true;
        }

        public override string Afficher()
        {
            return "Lapin[nom:" + _nom + ";dateDeNaissance:" + _dateDeNaissance + ";numeroDePuce:" + _numeroDePuce + ";taille:" + _taille + ";estAnimalDeConcours:" + _estAnimalDeConcours + ";tailleOreilles:" + _tailleOreilles + "]";
        }
    }
}