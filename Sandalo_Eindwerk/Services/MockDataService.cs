using Sandalo_Eindwerk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sandalo_Eindwerk.Services
{
    public class MockDataService : IDataService
    {
        private IList<Klant> _klanten;
        private IList<Bestelling> _bestellingen;

        public MockDataService()
        {
            InitialiseerLijsten();
        }
        private void InitialiseerLijsten()
        {
            Klant klant1 = new Klant() { Id = 1, Voornaam = "Paul", Familienaam = "Theunis", Straat = "Steenstraat 14", Postcode = 1000, Gemeente = "Brussel" };
            Klant klant2 = new Klant() { Id = 2, Voornaam = "Jan", Familienaam = "Womans", Straat = "Leopoldstraat 2", Postcode = 1020, Gemeente = "Brussel" };
            Klant klant3 = new Klant() { Id = 3, Voornaam = "Lieve", Familienaam = "Thorens", Straat = "Madelieflaan 427", Postcode = 2000, Gemeente = "Antwerpen" };
            Bestelling bestelling1Klant1 = new Bestelling()
            {
                BestelNr = 1,
                BestelDatum = new DateTime(2020, 10, 1),
                Omschrijving = "Beach Party",
                Prijs = 15.50,
                LeveringsPeriode = 7,
                IsGeleverd = true,
                Aantal = 2,
                Klant = "Paul Theunis"
            };
            Bestelling bestelling2Klant2 = new Bestelling()
            {
                BestelNr = 2,
                BestelDatum = new DateTime(2020, 10, 15),
                Omschrijving = "Beach Party",
                Prijs = 15.50,
                LeveringsPeriode = 7,
                IsGeleverd = true,
                Aantal = 1,
                Klant = "Jan Womans"
            };
            Bestelling bestelling3Klant3 = new Bestelling()
            {
                BestelNr = 3,
                BestelDatum = new DateTime(2020, 10, 2),
                Omschrijving = "Roman",
                Prijs = 35.50,
                LeveringsPeriode = 14,
                IsGeleverd = true,
                Aantal = 1,
                Klant = "Lieve Thorens"
            };
            Bestelling bestelling4Klant3 = new Bestelling()
            {
                BestelNr = 4,
                BestelDatum = new DateTime(2020, 11, 4),
                Omschrijving = "Retro Blue",
                LeveringsPeriode = 30,
                IsGeleverd = false,
                Aantal = 1,
                Klant = "Lieve Thorens"
            };

            klant1.Bestellingen.Add(bestelling1Klant1);

            klant2.Bestellingen.Add(bestelling2Klant2);

            klant3.Bestellingen.Add(bestelling3Klant3);
            klant3.Bestellingen.Add(bestelling4Klant3);

            _klanten = new List<Klant>();
            _klanten.Add(klant1);
            _klanten.Add(klant2);
            _klanten.Add(klant3);

            _bestellingen = new List<Bestelling>();
            _bestellingen.Add(bestelling1Klant1);
            _bestellingen.Add(bestelling2Klant2);
            _bestellingen.Add(bestelling3Klant3);
            _bestellingen.Add(bestelling4Klant3);
        }

        public IList<Klant> GeefAlleKlanten()
        {
            return _klanten;
        }
        public IList<Bestelling> GeefAlleBestellingen()
        {
            return _bestellingen;
        }
        public IList<Klant> VoegKlantToe(Klant klant)
        {
            int newId = _klanten.Count == 0 ? 1 : _klanten.Max(k => k.Id) + 1;
            klant.Id = newId;
            _klanten.Add(klant);
            return _klanten;
        }
        public void WijzigKlant(Klant klant)
        {
            int index = _klanten.IndexOf(klant);
            if (index >= 0) _klanten[index] = klant;
        }
        public IList<Klant> VerwijderKlant(Klant klant)
        {
            _klanten.Remove(klant);
            return _klanten;
        }
        public IList<Bestelling> VoegBestellingToeVoorKlant(Bestelling bestelling, Klant klant)
        {
            int index = _klanten.IndexOf(klant);
            if (index < 0) throw new ArgumentException($"Klant id= {klant.Id} niet gevonden");
            _klanten[index].Bestellingen.Add(bestelling);
            return _klanten[index].Bestellingen;
        }

        public IEnumerable<Bestelling> VoegBestellingToe(Bestelling bestelling)
        {
            int newBestelNr = _bestellingen.Count == 0 ? 1 : _bestellingen.Max(k => k.BestelNr) + 1;
            bestelling.BestelNr = newBestelNr;
            _bestellingen.Add(bestelling);
            return _bestellingen;
        }

        public void WijzigBestelling(Bestelling selectedBestelling)
        {
            int index = _bestellingen.IndexOf(selectedBestelling);
            if (index >= 0) _bestellingen[index] = selectedBestelling;
        }

        public IEnumerable<Bestelling> VerwijderBestelling(Bestelling selectedBestelling)
        {
            _bestellingen.Remove(selectedBestelling);
            return _bestellingen;
        }
    }
}
