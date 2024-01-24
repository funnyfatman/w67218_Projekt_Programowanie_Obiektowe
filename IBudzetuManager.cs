using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public interface IBudzetManager

    {

        void DodajDoBudzetu(decimal kwota);
        void OdejmijOdBudzetu(decimal kwota);
        string PobierzInformacjeOBudzecie();
        void DeaktywujBudzet();
        void ZmienWlasciciela(string nowyWlasciciel);
    }
}
