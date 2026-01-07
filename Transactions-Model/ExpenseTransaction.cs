using System;

namespace DigitalPettyCashLedger.Models
{

    // Represents an expense transaction in the petty cash system.
    // Inherits common transaction properties from the Transaction base class
    // and adds a Category to classify the expense.
    public class ExpenseTransaction : Transaction
    {
        // Category of the expense (e.g., Food, Travel, Office)
        public string Category { get; }

        // Initializes a new ExpenseTransaction with required details
        // including category-specific information.
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

        // Returns a formatted summary string for the expense transaction
        // demonstrating polymorphic behavior.
        public override string GetSummary()
        {
            return $"[EXPENSE] {Date:d} | {Category} | ${Amount} | {Description}";
        }
    }
}