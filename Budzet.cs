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
        public bool JestAktywny { get; set; } = true; 

        public Budzet(int id, decimal kwota, string wlasciciel)
        {
            Id = id;
            Kwota = kwota;
            Wlasciciel = wlasciciel;
        }

        public void DodajDoBudzetu(decimal kwota)
        {
            if (JestAktywny) Kwota += kwota;
        }

        public void OdejmijOdBudzetu(decimal kwota)
        {
            if (JestAktywny) Kwota -= kwota;
        }

        
        public string PobierzInformacjeOBudzecie()
        {
            return $"ID: {Id}, Kwota: {Kwota}, Właściciel: {Wlasciciel}, Aktywny: {JestAktywny}";
        }

        
        public void DeaktywujBudzet()
        {
            JestAktywny = false;
        }

        
        public void ZmienWlasciciela(string nowyWlasciciel)
        {
            if (JestAktywny) Wlasciciel = nowyWlasciciel;
        }
    }

}
