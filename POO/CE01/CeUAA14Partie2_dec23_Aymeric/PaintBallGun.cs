using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeUAA14Partie2_dec23_Aymeric
{
    internal class PaintBallGun
    {
        private Chargeur? _chargeur;

		public Chargeur? Chargeur
		{
			get { return _chargeur; }
		}

		public PaintBallGun() {}

        /// <summary>
        /// Tirer une balle du chargeur de l'arme.
        /// </summary>
        /// <returns>Le résultat de l'opération soit SUCCESS soit une erreur</returns>
        public Resultat Tirer()
		{
			if (_chargeur == null)
			{
				return Resultat.E_AUCUN_CHARGEUR_ARME;
			}
			return _chargeur.RecupererBalle();
		}

        /// <summary>
        /// Recharger l'arme
        /// </summary>
        /// <param name="chargeur">Nouveau chargeur</param>
        /// <param name="oldChargeur">Ancien chargeur (vide ou non)</param>
        /// <returns>Le résultat de l'opération soit SUCCESS soit une erreur</returns>
        public Resultat Recharger(Chargeur chargeur, out Chargeur? oldChargeur)
		{
			oldChargeur = null;

			if (_chargeur != null && _chargeur.NombreBalle == 16)
			{
				return Resultat.E_CHARGEUR_REMPLI;
			}

			if (_chargeur != null && _chargeur.NombreBalle >= chargeur.NombreBalle)
			{
				return Resultat.E_PAS_BESOIN_CHARGER;
			}

			oldChargeur = _chargeur;

            _chargeur = chargeur;

            return Resultat.SUCCESS;
		}
	}
}
