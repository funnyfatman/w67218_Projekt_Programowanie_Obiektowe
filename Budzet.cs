using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Budzet: IBudzet
    {
        public int ID { get; set; }
        public double DostepneSrodki { get; set; }
        public List<Budzet> budzety = new List<Budzet>();


        public  void DodajBudzet(double dostepneSrodki)
        {
            if (dostepneSrodki < 0)
            {
                throw new ArgumentException("Dostepne srodki muszą być wartością dodatnią.");
            }
            Budzet nowyBudzet = new Budzet { ID = budzety.Count + 1, DostepneSrodki = dostepneSrodki };
            budzety.Add(nowyBudzet);
        }


        public  Budzet PobierzBudzet(int id)
        {
            var budzet = budzety.FirstOrDefault(b => b.ID == id);
            if (budzet == null)
            {
                throw new KeyNotFoundException("Budzet o podanym ID nie istnieje.");
            }
            return budzet;
        }


        public  void AktualizujBudzet(int id, double noweDostepneSrodki)
        {
            var budzet = PobierzBudzet(id);
            if (budzet != null)
            {
                budzet.DostepneSrodki = noweDostepneSrodki;
            }
        }


        public  void UsunBudzet(int id)
        {
            budzety.RemoveAll(b => b.ID == id);
        }
    }
}
