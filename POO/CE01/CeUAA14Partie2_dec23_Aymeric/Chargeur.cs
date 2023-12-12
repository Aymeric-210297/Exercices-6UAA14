using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA14Partie2_dec23_Aymeric
{
    internal class Chargeur
    {
        private int _nombreBalle;

		public int NombreBalle
		{
			get { return _nombreBalle; }
		}

		public Chargeur(int nombreBalle = 16)
		{
			_nombreBalle = nombreBalle;
		}
		
		/// <summary>
		/// Récupérer une balle pour la tirer.
		/// </summary>
		/// <returns>Le résultat de l'opération soit SUCCESS soit une erreur</returns>
		public Resultat RecupererBalle()
		{
			if (_nombreBalle == 0)
			{
				return Resultat.E_CHARGEUR_VIDE;
			}
			_nombreBalle--;
			return Resultat.SUCCESS;
		}
	}
}
