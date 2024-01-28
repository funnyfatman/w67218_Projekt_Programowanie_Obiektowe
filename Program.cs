using BudzetDomowyProjekt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
namespace BudzetDomowyProjekt
{
    class Program
    {
        static void Main(string[] args)
        {
            

                BudgetApp budgetApp = new BudgetApp(1);
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Aplikacja do śledzenia wydatków i budżetu osobistego");
                Console.WriteLine("1. Dodaj kategorię wydatków");
                Console.WriteLine("2. Edytuj kategorię wydatków");
                Console.WriteLine("3. Usuń kategorię wydatków");
                Console.WriteLine("4. Dodaj transakcję");
                Console.WriteLine("5. Edytuj transakcję");
                Console.WriteLine("6. Usuń transakcję");
                Console.WriteLine("7. Wyświetl transakcje");
                Console.WriteLine("8. Wyjście");
                Console.Write("Wybierz opcję: ");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Write("Podaj nazwę nowej kategorii: ");
                        string newCategoryName = Console.ReadLine();
                        budgetApp.AddExpenseCategory(newCategoryName);
                        break;
                    case "2":
                        Console.Write("Podaj ID kategorii do edycji: ");
                        if (int.TryParse(Console.ReadLine(), out int categoryIDToEdit))
                        {
                            Console.Write("Podaj nową nazwę kategorii: ");
                            string newCategoryNameToEdit = Console.ReadLine();
                            budgetApp.EditExpenseCategory(categoryIDToEdit, newCategoryNameToEdit);
                        }
                        break;
                    case "3":
                        Console.Write("Podaj ID kategorii do usunięcia: ");
                        if (int.TryParse(Console.ReadLine(), out int categoryIDToDelete))
                        {
                            budgetApp.DeleteExpenseCategory(categoryIDToDelete);
                        }
                        break;
                    case "4":
                        Console.Write("Opis transakcji: ");
                        string transactionDescription = Console.ReadLine();
                        string payMethod="";
                        // Wybieramy dodatkową metodę płatności
                        try
                        {
                            Console.WriteLine("Wybierz metodę płatności:");
                            Console.WriteLine("1. Gotówka");
                            Console.WriteLine("2. Karta");
                            Console.Write("Wybierz opcję: ");
                            payMethod = Console.ReadLine();

                            // Walidacja danych
                            if (payMethod == "1" || payMethod == "2")
                            {
                                Console.WriteLine( "OK");
                            }
                            else
                            {
                                throw new Exception("Wprowadzona wartość to nie jest ani karta ani gotówka."); 
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Wprowadzona wartość nie jest liczbą całkowitą.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Błąd: " + ex.Message);
                        }
                        // Dodać walidacje                       
                        
                       

                        Console.Write("Kwota: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal transactionAmount))
                        {
                            Console.Write("Data transakcji (RRRR-MM-DD): ");
                            if (DateTime.TryParse(Console.ReadLine(), out DateTime transactionDate))
                            {
                                Console.Write("ID kategorii: ");
                                if (int.TryParse(Console.ReadLine(), out int transactionCategoryID))
                                {
                                    // W instacji programu BudgetApp wywołujemy metodę AddTransaction_Fake
                                    // , która na podstawie wybranej metody płatności
                                    // wywoła odpowiednią metodę AddTransaction (PRAWDZIWĄ)
                                    // w zależności od wstrzykniętej zależności
                                    budgetApp.AddTransaction_Fake(transactionDescription, transactionAmount, transactionDate, transactionCategoryID, payMethod);
                                }
                            }
                        }
                        break;
                    case "5":
                        Console.Write("Podaj ID transakcji do edycji: ");
                        if (int.TryParse(Console.ReadLine(), out int transactionIDToEdit))
                        {
                            Console.Write("Nowy opis transakcji: ");
                            string newTransactionDescription = Console.ReadLine();
                            Console.Write("Nowa kwota: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal newTransactionAmount))
                            {
                                Console.Write("Nowa data transakcji (RRRR-MM-DD): ");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime newTransactionDate))
                                {
                                    Console.Write("Nowe ID kategorii: ");
                                    if (int.TryParse(Console.ReadLine(), out int newTransactionCategoryID))
                                    {
                                        budgetApp.EditTransaction(transactionIDToEdit, newTransactionDescription, newTransactionAmount, newTransactionDate, newTransactionCategoryID);
                                    }
                                }
                            }
                        }
                        break;
                    case "6":
                        Console.Write("Podaj ID transakcji do usunięcia: ");
                        if (int.TryParse(Console.ReadLine(), out int transactionIDToDelete))
                        {
                            budgetApp.DeleteTransaction(transactionIDToDelete);
                        }
                        break;

                    case "7":
                        budgetApp.DisplayTransactions();
                        Console.WriteLine("Wciśnij Enter, aby kontynuować.");
                        Console.ReadLine();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Wciśnij Enter, aby kontynuować.");
                        Console.ReadLine();
                        break;
                }
            }

        }
    }
}
