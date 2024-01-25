using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public interface IBudzet
    {
        void DodajBudzet(double dostepneSrodki);
        Budzet PobierzBudzet(int id);
        void AktualizujBudzet(int id, double noweDostepneSrodki);
        void UsunBudzet(int id);
    }
}
