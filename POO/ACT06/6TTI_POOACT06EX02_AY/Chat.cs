using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT06EX02_AY
{
    internal class Chat : Animal
    {
        public Chat(string nom, string dateDeNaissance, string numeroDePuce, double taille, bool estAnimalDeConcours)
        {
            _nom = nom;
            _dateDeNaissance = dateDeNaissance;
            _numeroDePuce = numeroDePuce;
            _taille = taille;
            _estAnimalDeConcours = estAnimalDeConcours;
        }

        public override bool Manger()
        {
            Console.WriteLine(_nom + " vient de manger ses croquettes.");
            return true;
        }

        public bool Miauler()
        {
            Console.WriteLine(_nom + " vient de miauler.");
            return true;
        }

        public bool Ronronner()
        {
            Console.WriteLine(_nom + " vient de ronronner.");
            return true;
        }

        public override string Afficher()
        {
            return "Chat[nom:" + _nom + ";dateDeNaissance:" + _dateDeNaissance + ";numeroDePuce:" + _numeroDePuce + ";taille:" + _taille + ";estAnimalDeConcours:" + _estAnimalDeConcours + "]";
        }
    }
}
