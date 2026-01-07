using System;

namespace DigitalPettyCashLedger.Models
{
    public class IncomeTransaction : Transaction
    {
        public string Source {get;}

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

        public override string GetSummary()
        {
            return $"[Income] {Date:d} | {Source} | ${Amount} | {Description}";
        }
    }
}