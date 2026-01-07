using System;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Ledger;


namespace DigitalPettyCashLedger.Calculation
{
    // LedgerCalculator is a static utility class responsible for performing
    // read-only financial calculations on Ledger data.
    // It contains no state and cannot modify ledger contents,
    // ensuring immutability and separation of concerns.
    public static class LedgerCalculator
    {

        // Calculates the total amount of all transactions stored in the given ledger.
        // The generic constraint ensures only Transaction-based ledgers are accepted.
        public static decimal CalculateTotal<T>(Ledger<T> ledger) where T : Transaction
        {
            decimal total = 0;
            foreach (var t in ledger.GetAll())
            {
                total += t.Amount;
            }

            return total;
        }


        // Calculates the net balance by subtracting total expenses
        // from total income using their respective ledgers.

        public static decimal CalculateNetBalance(
            Ledger<IncomeTransaction> incomeLedger,
            Ledger<ExpenseTransaction> expenseLedger)
        {
            decimal totalIncome = CalculateTotal(incomeLedger);
            decimal totalExpense = CalculateTotal(expenseLedger);

            return totalIncome - totalExpense;
        }

    }
}