using Sandalo_Eindwerk.Models;
using System.Collections.Generic;

namespace Sandalo_Eindwerk.Services
{
    public interface IDataService
    {
        IList<Bestelling> GeefAlleBestellingen();
        IList<Klant> GeefAlleKlanten();
        IList<Klant> VerwijderKlant(Klant klant);
        IList<Bestelling> VoegBestellingToeVoorKlant(Bestelling bestelling, Klant klant);
        IList<Klant> VoegKlantToe(Klant klant);
        void WijzigKlant(Klant klant);
        IEnumerable<Bestelling> VoegBestellingToe(Bestelling bestelling);
        void WijzigBestelling(Bestelling selectedBestelling);
        IEnumerable<Bestelling> VerwijderBestelling(Bestelling selectedBestelling);
    }
}