using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT01EX01_AY
{
    internal class Chien
    {
        private string _nom;
        private string _race;
        private uint _age;
        private string _genre;
        private bool _estVaccine;

        public uint Age
        {
            get { return _age; }
            set { _age = value; }
        }


        public Chien(string nom, string race, uint age, bool estVaccine, string genre)
        {
            _nom = nom;
            _race = race;
            _age = age;
            _genre = genre;
            _estVaccine = estVaccine;
        }

        public void Vaccine()
        {
            _estVaccine = true;
        }

        public string AfficheCaracteristiques()
        {
            return "Chien[Nom: " + _nom + "; " + "Race: " + _race + "; " + "Age: " + _age + "; " + "Genre: " + _genre + "; " + "EstVaccine: " + _estVaccine + "]";
        }
    }
}
