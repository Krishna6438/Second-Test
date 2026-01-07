using System;

namespace DigitalPettyCashLedger.Models
{
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; }

        public ExpenseTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }

        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} | {Category} | ${Amount} | {Description}";
        }
    }
}