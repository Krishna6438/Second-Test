using System;
using System.Linq;
using DigitalPettyCashLedger.Models;
using System.Collections.Generic;

namespace DigitalPettyCashLedger.Ledger
{
    // Defines a generic Ledger class where T must inherit from Transaction,
    // ensuring type safety and access to common transaction properties
    public class Ledger<T> where T : Transaction
    {
        private List<T> transactions = new();

        public void AddEntry(T transaction)
        {
            transactions.Add(transaction);
        }

        public List<T> GetTransactionsByDate(DateTime date)
        {
            List<T> result = new ();
            foreach(T t in transactions)
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