using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.Components.Model
{
    internal class UserTransaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public double Amount { get; set; }
        public string TransactionType { get; set; } // "Credit", "Debit", "Debt"
        public string Tag { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }

        // Debt-specific properties
        public bool IsCleared { get; set; } = false; // Default: not cleared
        public DateTime? DueDate { get; set; } // Optional for debts
        public string Source { get; set; } // Optional for debts

        // Constructor
        public UserTransaction(string title, double amount, string transactionType, string tag, DateTime date, string note, DateTime? dueDate = null, string source = null)
        {
            Title = title;
            Amount = amount;
            TransactionType = transactionType;
            Tag = tag;
            Date = date;
            Note = note;

            if (transactionType == "debt")
            {
                DueDate = dueDate ?? throw new ArgumentNullException(nameof(dueDate), "Due date is required for debts.");
                Source = source ?? throw new ArgumentNullException(nameof(source), "Source is required for debts.");
            }
            else
            {
                // Ensure non-debt transactions don't have debt-specific fields
                DueDate = null;
                Source = null;
                IsCleared = false;
            }
        }
    }
}

