using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_WPFACT07_AY
{
    class Pari
    {
        private int _ecus;
        private Chien _chien;

        public int Ecus
        {
            get { return _ecus; }
        }

        public Chien Chien
        {
            get { return _chien; }
        }

        public Pari(int ecus, Chien chien)
        {
            _ecus = ecus;
            _chien = chien;
        }
    }
}
