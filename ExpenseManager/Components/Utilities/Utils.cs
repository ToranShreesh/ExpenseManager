
using ExpenseManager.Components.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ExpenseManager.Components.Utilities
{
    public class Utils
    {
        public static string ROOTFOLDER = Path.Combine(Environment.GetFolderPath(
            Environment.SpecialFolder.Desktop), "ExpenseManager");

      
        public static string TRANSACTIONS = Path.Combine(ROOTFOLDER, "transactions.json");
        public static string TAGS = Path.Combine(ROOTFOLDER, "tags.json");


        public static Guid CURRENTUSER = Guid.Empty;
        public static bool ISAUTHENTICATED = false;

        public static double income = 0;
        public static double expense = 0;
        public static double debt = 0;

        public static List<UserTransaction> GetTransaction()
        {
            List<UserTransaction> transactions = new();
            try
            {
                var lines = File.ReadAllLines(Utils.TRANSACTIONS);
                transactions = lines
                    .Select(line => JsonSerializer.Deserialize<UserTransaction>(line))
                    .Where(transaction => transaction != null)
                    .ToList();
                return transactions;
            }
            catch (Exception ex)
            {
                return transactions;
            }
        }

        public static List<string> GetTags()
        {
            List<string> tags = new List<string>();

            try
            {
                var lines = File.ReadAllLines(Utils.TAGS);
                string json = string.Join("", lines);

                tags = string.IsNullOrWhiteSpace(json)
                    ? new List<string>()
                    : JsonSerializer.Deserialize<List<string>>(json);
            }
            catch (Exception ex)
            {

            }
            return tags;
        }
       

        public static double Balance()
        {
            try
            {
                var transactions = GetTransaction();
                var income = transactions.Where(t => t.TransactionType == "income").Sum(t => t.Amount);
                var expense = transactions.Where(t => t.TransactionType == "expense").Sum(t => t.Amount);
                var debt = transactions
                    .Where(t => t.TransactionType == "debt" && !t.IsCleared)
                    .Sum(t => t.Amount);

                return income + debt - expense;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
