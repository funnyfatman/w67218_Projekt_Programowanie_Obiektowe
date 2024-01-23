using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Wydatki
    {
        public int Id { get; set; }
        public double Kwota { get; set; }
        public string Kategoria { get; set; }
        public DateTime DataWydatku { get; set; }

        public Wydatki(int Id,double Kwota,string Kategoria,DateTime DataWydatku)
        {
            this.Id = Id;
            this.Kwota = Kwota;
            this.Kategoria = Kategoria;
            this.DataWydatku = DataWydatku;
        }

    }
}
