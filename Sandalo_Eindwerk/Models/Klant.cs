using Sandalo_Eindwerk.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Sandalo_Eindwerk.Models
{
    public class Klant : ObservableObject
    {
        private int _id;
        private ObservableCollection<Bestelling> _bestellingen;
        private string _voornaam;
        private string _familienaam;
        private string _straat;
        private short? _postcode;
        private string _gemeente;

        public int Id { get { return _id; } set { OnPropertyChanged(ref _id, value); } }
        public string Voornaam { get { return _voornaam; } set { OnPropertyChanged(ref _voornaam, value); } }
        public string Familienaam { get { return _familienaam; } set { OnPropertyChanged(ref _familienaam, value); } }
        public string Straat { get { return _straat; } set { OnPropertyChanged(ref _straat, value); } }
        public short? Postcode { get { return _postcode; } set { OnPropertyChanged(ref _postcode, value); } }
        public string Gemeente { get { return _gemeente; } set { OnPropertyChanged(ref _gemeente, value); } }

        public Klant()
        {
            _bestellingen = new ObservableCollection<Bestelling>();
        }

        public ObservableCollection<Bestelling> Bestellingen
        {
            get
            {
                return _bestellingen;
            }
            set
            {
                OnPropertyChanged(ref _bestellingen, value);
            }
        }
        public override string ToString()
        {
            return this.Voornaam + " " + this.Familienaam;
        }
    }
}
