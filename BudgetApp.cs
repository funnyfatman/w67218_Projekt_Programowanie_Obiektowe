using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BudzetDomowyProjekt
{
    
    public class BudgetApp
    {
        public int ID { get; set; }
        private List<ExpenseCategory> expenseCategories = new List<ExpenseCategory>();
        private List<Transaction> transactions = new List<Transaction>();

        // Metoda do dodawania nowej Kategorii 
        public void AddExpenseCategory(string categoryName)
        {
            string connectionString = "Data Source=DESKTOP-RNTP4PI;DataBase=BudzetDomowyProjekt;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertDataQuery = $"INSERT INTO ExpenseCategory ( Name) VALUES ('{categoryName}')";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Dodano Kategorie");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }

            }
            int newID = expenseCategories.Count + 1;
            ExpenseCategory newCategory = new ExpenseCategory { ID = newID, Name = categoryName };
            expenseCategories.Add(newCategory);
        }
        // Metoda do wyświetlania transakcji
        public void DisplayTransactions()
        {
            string connectionString = "Data Source=DESKTOP-RNTP4PI;DataBase=BudzetDomowyProjekt;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectDataQuery = "SELECT * FROM Transactions";
                using (SqlCommand selectDataCommand = new SqlCommand(selectDataQuery,
               connection))
                {
                    using (SqlDataReader reader = selectDataCommand.ExecuteReader())
                    {
                        Console.WriteLine("\nLista osób w bazie danych:");
                        while (reader.Read())
                        {
                            string Description = reader["Description"].ToString();
                            string Amount = reader["Amount"].ToString();
                            string TransactionDate=reader["TransactionDate"].ToString();
                            string Category = reader["Category"].ToString();
                            string PayMethod = reader[""].ToString();
                           
                            
                        }
                    }
                }

            }
            Console.WriteLine("Lista transakcji:");
            foreach (var transaction in transactions)
            {
                Console.WriteLine($"ID: {transaction.ID}");
                Console.WriteLine($"Opis: {transaction.Description}");
                Console.WriteLine($"Kwota: {transaction.Amount}");
                Console.WriteLine($"Data transakcji: {transaction.TransactionDate}");
                Console.WriteLine($"Kategoria: {transaction.Category.Name}");
                //Console.WriteLine( $"Metoda płatności: {transaction.paymethod}");
                Console.WriteLine();
            }
        }
        // Metoda do edycji istniejącej Kategorii 
        public void EditExpenseCategory(int categoryID, string newName)
        {
            ExpenseCategory categoryToEdit = expenseCategories.FirstOrDefault(c => c.ID == categoryID);
            if (categoryToEdit != null)
            {
                categoryToEdit.Name = newName;
            }
        }

        // Metoda do usuwania Kategorii Wydatków
        public void DeleteExpenseCategory(int categoryID)
        {
            ExpenseCategory categoryToDelete = expenseCategories.FirstOrDefault(c => c.ID == categoryID);
            if (categoryToDelete != null)
            {
                expenseCategories.Remove(categoryToDelete);
            }
        }

        // Metoda do dodawania nowej Transakcji wraz z wstrzykiwaniem zależności
        public void AddTransaction_Fake(string description, decimal amount, DateTime transactionDate, int categoryID, string pay_method)
        {
            string connectionString = "Data Source=DESKTOP-RNTP4PI;DataBase=BudzetDomowyProjekt;Integrated Security=True;";


            using (SqlConnection connection = new SqlConnection(connectionString))
           {
               connection.Open();

                string insertDataQuery = $"INSERT INTO Transactions ( Description, Amount,TransactionDate,Category,PayMethod)VALUES('{description}', '{amount}', {transactionDate}, {categoryID},{pay_method})";

                using (SqlCommand insertDataCommand = new SqlCommand(insertDataQuery, connection))
                {
                    try 
                    {
                        insertDataCommand.ExecuteNonQuery();
                        Console.WriteLine($"Dodano Transakcję");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Błąd przy dodawaniu danych: {ex.Message}");
                    }
                }
                  
            }
            int newID = transactions.Count + 1;
            ExpenseCategory category = expenseCategories.FirstOrDefault(c => c.ID == categoryID);
            if (category != null)
            {

                if (pay_method == "Cash")
                {
                    // Tutaj wstrzykujemy zależność                    
                    IPayMethod payMethodCash = new CashAddTransaction();

                    Transaction_Fake transaction_Fake_Cash = new Transaction_Fake(payMethodCash);
                    transactions.Add(transaction_Fake_Cash.GetTransaction(newID, description, amount, transactionDate, categoryID));
                }
                else if (pay_method == "Card")
                {
                    // Tutaj wstrzykujemy zależność

                    IPayMethod payMethodCard = new CardAddTransaction();

                    Transaction_Fake transaction_Fake_Card = new Transaction_Fake(payMethodCard);

                    transactions.Add(transaction_Fake_Card.GetTransaction(newID, description, amount, transactionDate, categoryID));
                }
                else
                {
                    Console.WriteLine("Nie ma takiej metody płatności");
                }
            }
        }
    

    

    

        // Metoda do edycji istniejącej Transakcji
        public void EditTransaction(int transactionID, string newDescription, decimal newAmount, DateTime newTransactionDate, int newCategoryID)
        {
            Transaction transactionToEdit = transactions.FirstOrDefault(t => t.ID == transactionID);
            if (transactionToEdit != null)
            {
                transactionToEdit.Description = newDescription;
                transactionToEdit.Amount = newAmount;
                transactionToEdit.TransactionDate = newTransactionDate;
                ExpenseCategory newCategory = expenseCategories.FirstOrDefault(c => c.ID == newCategoryID);
                if (newCategory != null)
                {
                    transactionToEdit.Category = newCategory;
                }
            }
        }

        // Metoda do usuwania Transakcji
        public void DeleteTransaction(int transactionID)
        {
            Transaction transactionToDelete = transactions.FirstOrDefault(t => t.ID == transactionID);
            if (transactionToDelete != null)
            {
                transactions.Remove(transactionToDelete);
            }
        }
public BudgetApp(int ID)
{
    this.ID = ID; 
}
    }
}
