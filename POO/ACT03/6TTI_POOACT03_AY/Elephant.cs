using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6TTI_POOACT03_AY
{
    internal class Elephant
    {
        private string _nom;
        private uint _tailleOreilles;

        public Elephant(string nom, uint tailleOreilles)
        {
            _nom = nom;
            _tailleOreilles = tailleOreilles;
        }

        public string Nom
        {
            get { return _nom; }
        }

        public uint TailleOreilles
        {
            get { return _tailleOreilles; }
        }

        
        /// <summary>
        /// Afficher les caractéristiques de l'éléphant
        /// </summary>
        /// <returns>Le nom et la taille des oreilles de l'éléphant</returns>
        public string AfficheQuiJeSuis()
        {
            return "Je m'appelle " + _nom + ".\nMes oreilles mesurent " + _tailleOreilles + "cm.";
        }

        /// <summary>
        /// Rcevoir un message d'un autre éléphant
        /// </summary>
        /// <param name="message">Le message de l'autre éléphant</param>
        /// <param name="quiDit">L'éléphant qui envoie le message</param>
        public void EcouteMessage(string message, Elephant quiDit) {
            Console.WriteLine(_nom + " a entendu un message \n" + quiDit._nom + " a dit : " + message);
        }

        /// <summary>
        /// Envoyer un message à un autre éléphant
        /// </summary>
        /// <param name="message">Le message que l'éléhant doit envoyer</param>
        /// <param name="quiRecoit">L'éléphant qui doit recevoir le message</param>
        public void EnvoieMessage(string message, Elephant quiRecoit)
        {
            quiRecoit.EcouteMessage(message, this);
        }
    }
}
