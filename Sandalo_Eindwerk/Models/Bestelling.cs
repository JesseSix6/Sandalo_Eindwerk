using Sandalo_Eindwerk.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo_Eindwerk.Models
{
    public class Bestelling : ObservableObject
    {
        private string _klant;
        private int _bestelNr;
        private DateTime _bestelDatum;
        private int _leveringsPeriode;
        private string _omschrijving;
        private double _prijs;
        private bool _isGeleverd;
        private int _aantal;

        public string Klant { get { return _klant; } set { OnPropertyChanged(ref _klant, value); } }
        public int BestelNr { get { return _bestelNr; } set { OnPropertyChanged(ref _bestelNr, value); } }
        public DateTime BestelDatum { get { return _bestelDatum; } set { OnPropertyChanged(ref _bestelDatum, value); } }
        public int LeveringsPeriode { get { return _leveringsPeriode; } set { OnPropertyChanged(ref _leveringsPeriode, value); } }
        public string Omschrijving { get { return _omschrijving; } set { OnPropertyChanged(ref _omschrijving, value); } }
        public double Prijs { get { return _prijs; } set { OnPropertyChanged(ref _prijs, value); } }
        public int Aantal { get { return _aantal; } set { OnPropertyChanged(ref _aantal, value); } }
        public bool IsGeleverd { get { return _isGeleverd; } set { OnPropertyChanged(ref _isGeleverd, value); } }
    }
}
