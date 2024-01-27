using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudzetDomowyProjekt
{
    public class Transaction
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public ExpenseCategory Category { get; set; }
        
    }
}
