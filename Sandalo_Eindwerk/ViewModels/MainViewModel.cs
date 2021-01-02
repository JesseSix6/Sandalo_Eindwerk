using Sandalo_Eindwerk.Services;
using Sandalo_Eindwerk.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sandalo_Eindwerk.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private IDataService _dataService;
        private KlantenViewModel _klantenVM;
        private BestellingenViewModel _bestellingenVM;

        public MainViewModel()
        {
            _dataService = new MockDataService();
            _klantenVM = new KlantenViewModel(_dataService);
            _bestellingenVM = new BestellingenViewModel(_dataService);
        }

        public KlantenViewModel KlantenVM
        {
            get { return _klantenVM; }
            set { OnPropertyChanged(ref _klantenVM, value); }
        }

        public BestellingenViewModel BestellingenVM
        {
            get { return _bestellingenVM; }
            set { OnPropertyChanged(ref _bestellingenVM, value); }
        }
    }
}
