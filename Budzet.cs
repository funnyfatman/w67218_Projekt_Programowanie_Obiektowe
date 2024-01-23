using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Budzet
    {
        public int Id { get; set; }
        public decimal Kwota { get; set; }
        public string Wlasciciel { get; set; }
        public string Kategoria { get; set; }

        public Budzet(int id, decimal kwota, string kategoria, string wlasciciel)
        {
            Id = id;
            Kwota = kwota;
            Kategoria = kategoria;
            Wlasciciel = wlasciciel;

        }

    }
}
