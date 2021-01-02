using Sandalo_Eindwerk.Models;
using Sandalo_Eindwerk.Services;
using Sandalo_Eindwerk.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace Sandalo_Eindwerk.ViewModels
{
    public class KlantenViewModel : ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Klant> _klanten;
        private Klant _selectedKlant;
        public KlantenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            Klanten = new ObservableCollection<Klant>(_dataService.GeefAlleKlanten());
            AddKlantCommand = new RelayCommand(VoegKlantToe);
            UpdateKlantCommand = new RelayCommand(WijzigKlant);
            DeleteKlantCommand = new RelayCommand(VerwijderKlant);
        }
        private void VerwijderKlant()
        {
            Klanten = new ObservableCollection<Klant>(_dataService.VerwijderKlant(SelectedKlant));
        }

        private void WijzigKlant()
        {
            _dataService.WijzigKlant(SelectedKlant);
        }

        private void VoegKlantToe()
        {
            Klant klant = new Klant() { Voornaam = "NA", Familienaam = "NA", Gemeente = "Gemeente", Postcode = 1000, Straat = "Straat", Bestellingen = new ObservableCollection<Bestelling>() };
            Klanten = new ObservableCollection<Klant>(_dataService.VoegKlantToe(klant));
            SelectedKlant = _klanten[_klanten.Count - 1];
        }
        public ICommand AddKlantCommand { get; private set; }
        public ICommand UpdateKlantCommand { get; private set; }
        public ICommand DeleteKlantCommand { get; private set; }
        public ObservableCollection<Klant> Klanten
        {
            get { return _klanten; }
            set { OnPropertyChanged(ref _klanten, value); }
        }
        public Klant SelectedKlant
        {
            get { return _selectedKlant; }
            set { OnPropertyChanged(ref _selectedKlant, value); }
        }
    }
}
