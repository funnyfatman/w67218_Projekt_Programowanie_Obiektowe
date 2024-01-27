using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public interface IPayMethod
    {
        public Transaction AddTransaction(int newID, string description, decimal amount, DateTime transactionDate, int categoryID);
    }
}
