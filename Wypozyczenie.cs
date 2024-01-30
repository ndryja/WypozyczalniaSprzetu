using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu
{
    public class Wypozyczenie
    {
        public int SprzetID { get; set; }
        public DateTime DataWypozyczenia { get; set; }
        public int LiczbaDni { get; set; }

        public Wypozyczenie(int sprzetID, DateTime dataWypozyczenia, int liczbaDni)
        {
            SprzetID = sprzetID;
            DataWypozyczenia = dataWypozyczenia;
            LiczbaDni = liczbaDni;
        }

        public decimal ObliczKoszt(decimal cenaZaDobe)
        {
            return LiczbaDni * cenaZaDobe;
        }
    }

}
