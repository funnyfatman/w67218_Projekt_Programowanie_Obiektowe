using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Budzet
    {
        public int ID { get; set; }
        public double DostepneSrodki { get; set; }
        private static List<Budzet> budzety = new List<Budzet>();


        public  void DodajBudzet(double dostepneSrodki)
        {
            Budzet nowyBudzet = new Budzet { ID = budzety.Count + 1, DostepneSrodki = dostepneSrodki };
            budzety.Add(nowyBudzet);
        }


        public  Budzet PobierzBudzet(int id)
        {
            return budzety.Find(b => b.ID == id);
        }


        public  void AktualizujBudzet(int id, double noweDostepneSrodki)
        {
            var budzet = PobierzBudzet(id);
            if (budzet != null)
            {
                budzet.DostepneSrodki = noweDostepneSrodki;
            }
        }


        public static void UsunBudzet(int id)
        {
            budzety.RemoveAll(b => b.ID == id);
        }
    }
}
