using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _6TTI_WPFACT07_AY
{
    class Chien
    {
        private int _numero;
        private int _vitesse;
        private Image _image;

        public int Numero
        {
            get { return _numero; }
        }

        public int Vitesse
        {
            get { return _vitesse; }
        }

        public Image Image
        {
            get { return _image; }
        }

        public Chien(int numero, int vitesse, Image image)
        {
            _numero = numero;
            _vitesse = vitesse;
            _image = image;
        }

        public bool FaireAvancer(int pas)
        {
            return false;
        }
    }
}
