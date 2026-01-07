using System;

namespace DigitalPettyCashLedger.Models
{

    // Represents an income transaction in the petty cash system.
    // Inherits common transaction details from the Transaction base class
    // and adds Source information to identify where the income came from.
    public class IncomeTransaction : Transaction
    {
        // Source of the income (e.g., Main Cash, Bank)
        public string Source { get; }

        // Initializes a new IncomeTransaction with income-specific details.
        public IncomeTransaction(
            int id,
            DateTime date,
            decimal amount,
            string description,
            string source)
            : base(id, date, amount, description)
        {
            Source = source;
        }

        // Returns a formatted summary string for the income transaction,
        // demonstrating polymorphic behavior.
        public override string GetSummary()
        {
            return $"[Income] {Date:d} | {Source} | ${Amount} | {Description}";
        }
    }
}