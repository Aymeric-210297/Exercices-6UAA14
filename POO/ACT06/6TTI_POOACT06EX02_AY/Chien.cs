using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX02_AY
{
    internal class Chien : Animal
    {
        public Chien(string nom, string dateDeNaissance, string numeroDePuce, double taille, bool estAnimalDeConcours)
        {
            _nom = nom;
            _dateDeNaissance = dateDeNaissance;
            _numeroDePuce = numeroDePuce;
            _taille = taille;
            _estAnimalDeConcours = estAnimalDeConcours;
        }

        public override bool Manger()
        {
            Console.WriteLine(_nom + " vient de manger sa pâtée.");
            return true;
        }

        public bool Aboyer()
        {
            Console.WriteLine(_nom + " vient d'aboyer.");
            return true;
        }

        public override string Afficher()
        {
            return "Chien[nom:" + _nom + ";dateDeNaissance:" + _dateDeNaissance + ";numeroDePuce:" + _numeroDePuce + ";taille:" + _taille + ";estAnimalDeConcours:" + _estAnimalDeConcours + "]";
        }
    }
}
