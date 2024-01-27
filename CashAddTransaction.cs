using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class CashAddTransaction : IPayMethod
    {
        public Transaction AddTransaction(int newID, string description, decimal amount, DateTime transactionDate, int categoryID)
        {
            Transaction transaction = new Transaction();
            transaction.ID = newID;
            transaction.Description = description;
            transaction.Amount = amount;
            transaction.PayMethod = "Cash";
            transaction.TransactionDate = transactionDate;
            transaction.Category = new ExpenseCategory() { ID = categoryID };

            return transaction;
        }
    }
}
