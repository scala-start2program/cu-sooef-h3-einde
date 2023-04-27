using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.ServiceClasses.Core
{
    public class Persoon
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public bool IsMan { get; set; }

        public Persoon()
        {
        }
        public Persoon(string naam, string voornaam, DateTime geboortedatum, bool isman)
        {
            Naam = naam;
            Voornaam = voornaam;
            Geboortedatum = geboortedatum;
            IsMan = isman;
        }

        public override string ToString()
        {
            return $"{Naam} {Voornaam}";
        }
        public string GetLeeftijd()
        {
            DateTime vandaag = DateTime.Now;
            int jaren = vandaag.Year - Geboortedatum.Year;
            int maanden = vandaag.Month - Geboortedatum.Month;
            int dagen = vandaag.Day - Geboortedatum.Day;

            if (maanden < 0 || (maanden == 0 && dagen < 0))
            {
                jaren--;
                maanden += 12;
                if (dagen < 0)
                {
                    dagen += DateTime.DaysInMonth(Geboortedatum.Year, Geboortedatum.Month);
                }
            }
            return $"{jaren} jaar, {maanden} maanden en {dagen} dagen";
        }

    }
}
