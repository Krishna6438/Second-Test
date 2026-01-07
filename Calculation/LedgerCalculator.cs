using System;
using DigitalPettyCashLedger.Models;
using DigitalPettyCashLedger.Ledger;


namespace DigitalPettyCashLedger.Calculation
{
    public static class LedgerCalculator
    {
        public static decimal CalculateTotal<T>(Ledger<T> ledger) where T : Transaction
        {
            decimal total = 0;
            foreach (var t in ledger.GetAll())
            {
                total += t.Amount;
            }

            return total;
        }

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