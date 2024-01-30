using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WypozyczalniaSprzetu
{
    public class Sprzet
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public decimal CenaZaDobe { get; set; }

        public Sprzet(int id, string nazwa, decimal cenaZaDobe)
        {
            ID = id;
            Nazwa = nazwa;
            CenaZaDobe = cenaZaDobe;
        }
    }
}
