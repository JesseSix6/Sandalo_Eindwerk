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
    public class BestellingenViewModel : ObservableObject
    {
        private IDataService _dataService;
        private ObservableCollection<Bestelling> _bestellingen;
        private Bestelling _selectedBestelling;
        public ICommand AddBestelling { get; private set; }
        public ICommand ChangeBestelling { get; private set; }
        public ICommand DeleteBestelling { get; private set; }
        public BestellingenViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _bestellingen = new ObservableCollection<Bestelling>(_dataService.GeefAlleBestellingen());
            AddBestelling = new RelayCommand(VoegBestellingToe);
            ChangeBestelling = new RelayCommand(WijzigBestelling);
            DeleteBestelling = new RelayCommand(VerwijderBestelling);
        }
        private void VerwijderBestelling()
        {
            Bestellingen = new ObservableCollection<Bestelling>(_dataService.VerwijderBestelling(SelectedBestelling));
            if (_bestellingen.Count > 0) SelectedBestelling = _bestellingen[0];
        }

        private void WijzigBestelling()
        {
            _dataService.WijzigBestelling(SelectedBestelling);
        }

        private void VoegBestellingToe()
        {
            Bestelling bestelling = new Bestelling() { BestelNr = 0, BestelDatum = DateTime.Today, LeveringsPeriode = 0, Omschrijving = "Sandaal", Prijs = 0, Aantal = 0 };
            Bestellingen = new ObservableCollection<Bestelling>(_dataService.VoegBestellingToe(bestelling));
        }

        public ObservableCollection<Bestelling> Bestellingen
        {
            get { return _bestellingen; }
            set { OnPropertyChanged(ref _bestellingen, value); }
        }
        public Bestelling SelectedBestelling
        {
            get { return _selectedBestelling; }
            set { OnPropertyChanged(ref _selectedBestelling, value); }
        }

    }
}
