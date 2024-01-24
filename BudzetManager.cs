using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class BudzetManager : IBudzetuManager
    {
        private Budzet _budzet;

        public BudzetManager(Budzet budzet)
        {
            _budzet = budzet;
        }
        void DodajDoBudzetu(decimal kwota)
        {
           if (JestAktywny) Kwota += kwota;
        }
        void OdejmijOdBudzetu(decimal kwota)
        {
            if (JestAktywny) Kwota -= kwota;
        }
        string PobierzInformacjeOBudzecie()
        {
            return $"ID: {Id}, Kwota: {Kwota}, Właściciel: {Wlasciciel}, Aktywny: {JestAktywny}";
        }
        void DeaktywujBudzet()
        {
            JestAktywny = false;
        }
        void ZmienWlasciciela(string nowyWlasciciel)
        {
            if (JestAktywny) Wlasciciel = nowyWlasciciel;
        }

    }

}
