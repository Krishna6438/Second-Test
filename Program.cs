using System;
using System.Collections.Generic;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Ledger;
using DigitalPettyCashLedger.Calculation;

namespace DigitalPettyCashLedger
{
    // Entry point of the Digital Petty Cash Ledger application.
    // This class handles user interaction through a menu-driven console interface
    // and coordinates operations between Ledger and LedgerCalculator.
    class Program
    {

        // Main execution loop of the application.
        // Displays menu options, accepts user input,
        // and routes control to appropriate operations.


        public static void Main()
        {
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

            while (true)
            {
                Console.WriteLine("\n---- DIGITAL PETTY CASH LEDGER ----");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View Summary");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddIncome(incomeLedger);
                        break;

                    case "2":
                        AddExpense(expenseLedger);
                        break;

                    case "3":
                        ShowSummary(incomeLedger, expenseLedger);
                        break;

                    case "4":
                        Console.WriteLine("Exiting application...");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        // ------------------ Helper Methods ------------------


        // Accepts user input to create and store an income transaction
        // in the income ledger after validating inputs.
        static void AddIncome(Ledger<IncomeTransaction> ledger)
        {
            int id = ReadInt("Enter Income ID: ");
            decimal amount = ReadDecimal("Enter Amount: ");

            Console.Write("Enter Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Enter Source (Main Cash / Bank): ");
            string source = Console.ReadLine()!;

            ledger.AddEntry(new IncomeTransaction(
                id: id,
                date: DateTime.Today,
                amount: amount,
                description: description,
                source: source
            ));

            Console.WriteLine("Income added successfully.");
        }

        // Accepts user input to create and store an expense transaction
        // in the expense ledger after validating inputs.
        static void AddExpense(Ledger<ExpenseTransaction> ledger)
        {
            int id = ReadInt("Enter Expense ID: ");
            decimal amount = ReadDecimal("Enter Amount: ");

            Console.Write("Enter Description: ");
            string description = Console.ReadLine()!;

            Console.Write("Enter Category (Food / Travel / Office): ");
            string category = Console.ReadLine()!;

            ledger.AddEntry(new ExpenseTransaction(
                id: id,
                date: DateTime.Today,
                amount: amount,
                description: description,
                category: category
            ));

            Console.WriteLine("Expense added successfully.");
        }


        // Displays total income, total expenses, and net balance
        // using the LedgerCalculator, and prints a transaction summary
        // using polymorphic behavior.
        static void ShowSummary(
            Ledger<IncomeTransaction> incomeLedger,
            Ledger<ExpenseTransaction> expenseLedger)
        {
            decimal totalIncome =
                LedgerCalculator.CalculateTotal(incomeLedger);

            decimal totalExpense =
                LedgerCalculator.CalculateTotal(expenseLedger);

            decimal balance =
                LedgerCalculator.CalculateNetBalance(incomeLedger, expenseLedger);

            Console.WriteLine("\n---- SUMMARY ----");
            Console.WriteLine($"Total Income   : {totalIncome}");
            Console.WriteLine($"Total Expense  : {totalExpense}");
            Console.WriteLine($"Net Balance    : {balance}");

            Console.WriteLine("\n---- TRANSACTIONS ----");
            List<Transaction> all = new List<Transaction>();
            all.AddRange(incomeLedger.GetAll());
            all.AddRange(expenseLedger.GetAll());

            foreach (var transaction in all)
            {
                Console.WriteLine(transaction.GetSummary());
            }
        }

        // ------------------ Utility Methods ------------------


        // Reads and validates integer input from the user,
        // repeatedly prompting until a valid number is entered.


        static int ReadInt(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid number. Please try again.");
            }
        }

        // Reads and validates decimal input from the user,
        // repeatedly prompting until a valid amount is entered.
        static decimal ReadDecimal(string message)
        {
            decimal value;
            while (true)
            {
                Console.Write(message);
                if (decimal.TryParse(Console.ReadLine(), out value))
                    return value;

                Console.WriteLine("Invalid amount. Please try again.");
            }
        }
    }
}
