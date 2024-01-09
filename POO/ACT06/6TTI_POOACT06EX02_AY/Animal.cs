using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX02_AY
{
    internal abstract class Animal
    {
        protected string _nom;
        protected string _dateDeNaissance;
        protected string _numeroDePuce;
        protected double _taille;
        protected bool _estAnimalDeConcours;

        public string Nom
        {
            get { return _nom; }
        }

        public string DateDeNaissance
        {
            get { return _dateDeNaissance; }
        }

        public string NumeroDePuce
        {
            get { return _numeroDePuce; }
            set { _numeroDePuce = value; }
        }

        public double Taille
        {
            get { return _taille; }
            set { _taille = value; }
        }

        public bool EstAnimalDeConcours
        {
            get { return _estAnimalDeConcours; }
            set { _estAnimalDeConcours = value; }
        }

        public abstract string Afficher();
        public abstract bool Manger();
        public bool Dormir()
        {
            Console.WriteLine(_nom + " vient de dormir.");
            return true;
        }
    }
}
