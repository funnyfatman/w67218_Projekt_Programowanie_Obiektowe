using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Uzytkownik
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        private static List<Uzytkownik> uzytkownicy = new List<Uzytkownik>();

        
        public  void DodajUzytkownika(string nazwa)
        {
            Uzytkownik nowyUzytkownik = new Uzytkownik { ID = uzytkownicy.Count + 1, Nazwa = nazwa };
            uzytkownicy.Add(nowyUzytkownik);
        }

        
        public  Uzytkownik PobierzUzytkownika(int id)
        {
            return uzytkownicy.Find(u => u.ID == id);
        }

        
        public  void AktualizujUzytkownika(int id, string nowaNazwa)
        {
            var uzytkownik = PobierzUzytkownika(id);
            if (uzytkownik != null)
            {
                uzytkownik.Nazwa = nowaNazwa;
            }
        }

        
        public  void UsunUzytkownika(int id)
        {
            uzytkownicy.RemoveAll(u => u.ID == id);
        }

    }
}
