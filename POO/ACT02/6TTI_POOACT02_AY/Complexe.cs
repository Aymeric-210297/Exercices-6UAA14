using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT02_AY
{
    internal class Complexe
    {
        private double _reelle;
        private double _imaginaire;

        public double Reelle
        {
            get { return _reelle; }
            set { _reelle = value; }
        }

        public double Imaginaire
        {
            get { return _imaginaire; }
            set { _imaginaire = value; }
        }

        public Complexe(double reelle, double imaginaire)
        {
            _reelle = reelle;
            _imaginaire = imaginaire;
        }

        public string AfficheComplexe()
        {
            return "(" + _reelle + ";" + _imaginaire + ")";
        }

        public double CalculeModule() {
            return Math.Round(Math.Sqrt(Math.Pow(Reelle, 2) + Math.Pow(Imaginaire, 2)));
        }

        public bool Ajoute(Complexe complexe)
        {
            this._reelle += complexe.Reelle;
            this._imaginaire += complexe.Imaginaire;
            return true;
        }
    }
}
