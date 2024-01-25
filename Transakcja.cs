using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Transakcja
    {
        public int ID { get; set; }
        public double Kwota { get; set; }
        public DateTime Data { get; set; }
        private static List<Transakcja> transakcje = new List<Transakcja>();


        public  void DodajTransakcje(double kwota, DateTime data)
        {
            int noweID = transakcje.Count + 1;
            transakcje.Add(new Transakcja { ID = noweID, Kwota = kwota, Data = data });
        }


        public  Transakcja PobierzTransakcje(int id)
        {
            return transakcje.Find(t => t.ID == id);
        }


        public  void AktualizujTransakcje(int id, double nowaKwota, DateTime nowaData)
        {
            var transakcja = PobierzTransakcje(id);
            if (transakcja != null)
            {
                transakcja.Kwota = nowaKwota;
                transakcja.Data = nowaData;
            }
        }


        public static void UsunTransakcje(int id)
        {
            transakcje.RemoveAll(t => t.ID == id);
        }

    }
}
