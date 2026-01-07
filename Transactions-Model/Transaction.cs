using System;
using DigitalPettyCashLedger.Interface;

namespace DigitalPettyCashLedger.Models
{
    public abstract class Transaction : IReportable
    {
        public int Id{get; set;}
        public DateTime Date{get;}
        public decimal Amount{get; protected set;}
        public string? Description{get;}


        protected Transaction(int id, DateTime date,decimal amount,string description)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;   
        }

        public abstract string GetSummary();

    }
}