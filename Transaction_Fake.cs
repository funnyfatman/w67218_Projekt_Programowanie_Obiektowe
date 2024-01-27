using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Transaction_Fake
    {
        private readonly IPayMethod _payMethod;

        public Transaction_Fake(IPayMethod payMethod)
        {
            _payMethod = payMethod;
        }

        public Transaction GetTransaction(int newID, string description, decimal amount, DateTime transactionDate, int categoryID)
        {
            return _payMethod.AddTransaction(newID, description, amount, transactionDate, categoryID);
        }


    }
}
