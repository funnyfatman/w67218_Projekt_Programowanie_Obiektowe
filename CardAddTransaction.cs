using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class CardAddTransaction : IPayMethod
    {
        public Transaction AddTransaction(int newID, string description, decimal amount, DateTime transactionDate, int categoryID)
        {
            Transaction transaction = new Transaction();
            transaction.ID = newID;
            transaction.Description = description;
            transaction.Amount = amount;
            transaction.PayMethod = "Card";
            transaction.TransactionDate = transactionDate;
            transaction.Category = new ExpenseCategory() { ID = categoryID };

            return transaction;
        }
    }
}
