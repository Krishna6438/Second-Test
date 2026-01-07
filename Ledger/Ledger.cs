using System;
using System.Linq;
using DigitalPettyCashLedger.Models;
using System.Collections.Generic;

namespace DigitalPettyCashLedger.Ledger
{
    // Ledger<T> is a generic in-memory container for storing financial transactions.
    // It accepts only Transaction-based types to ensure compile-time type safety.
    // The class is responsible only for storing and retrieving data,
    // not for performing any business calculations.
    public class Ledger<T> where T : Transaction
    {
        // Internal collection used to store transaction entries in memory
        private List<T> transactions = new();

        // Adds a new transaction entry to the ledger
        public void AddEntry(T transaction)
        {
            transactions.Add(transaction);
        }

        // Retrieves all transactions that occurred on the specified date
        public List<T> GetTransactionsByDate(DateTime date)
        {
            List<T> result = new();
            foreach (T t in transactions)
            {
                if (t.Date.Date == date.Date)
                {
                    result.Add(t);
                }
            }

            return result;
        }


        public List<T> GetAll()
        {
            return transactions;
        }
    }
}