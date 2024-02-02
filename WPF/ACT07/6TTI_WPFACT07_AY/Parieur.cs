﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace _6TTI_WPFACT07_AY
{
    class Parieur
    {
        private string _nom;
        private int _portefeuille;
        private Pari? _pariActuel;
        private TextBlock _textBlock;
        private RadioButton _radioButton;
        private TextBlock _textBlockParieurActuel;

        public string Nom
        {
            get { return _nom; }
        }

        public int Portefeuille
        {
            get { return _portefeuille; }
        }

        public Pari? PariActuel
        {
            get { return _pariActuel; }
        }
        public TextBlock TextBlock
        {
            get { return _textBlock; }
        }

        public RadioButton RadioButton
        {
            get { return _radioButton; }
        }

        public Parieur(string nom, int portefeuille, TextBlock textBlock, RadioButton radioButton, TextBlock textBlockParieurActuel)
        {
            _nom = nom;
            _portefeuille = portefeuille;
            _textBlock = textBlock;
            _radioButton = radioButton;

            _textBlockParieurActuel = textBlockParieurActuel;

            _radioButton.Checked += new RoutedEventHandler(CheckedEvent);

            RefreshInterface();
        }

        private void CheckedEvent(object sender, RoutedEventArgs e)
        {
            RefreshInterface();
        }

        private void RefreshInterface()
        {
            _radioButton.Content = _nom + " possède " + _portefeuille + " écus";
            if (_portefeuille < 5)
            {
                _radioButton.IsEnabled = false;
            }

            if (_pariActuel != null)
            {
                _textBlock.Text = _nom + " a parié " + _pariActuel.Ecus + " écus sur le chien numéro " + _pariActuel.Chien.Numero;
            } else
            {
                _textBlock.Text = _nom + " n'a pas encore parié";
            }

            if (_radioButton.IsChecked == true)
            {
                _textBlockParieurActuel.Text = _nom;
            }
        }

        public void AjouterPortefeuille(int ecus)
        {
            _portefeuille += ecus;
            RefreshInterface();
        }

        public bool RetirerPortefeuille(int ecus)
        {
            if (_portefeuille >= ecus)
            {
                _portefeuille -= ecus;
                RefreshInterface();
                return true;
            }
            return false;
        }

        public bool Parier(int ecus, Chien chien)
        {
            if (!RetirerPortefeuille(ecus))
            {
                return false;
            }
            _pariActuel = new Pari(ecus, chien);
            RefreshInterface();
            return true;
        }
    }
}
