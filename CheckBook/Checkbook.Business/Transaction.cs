using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Checkbook.Data;
using System.Configuration;
using System.Data;
namespace Checkbook.Business
{
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(int transactionID)
        {
            GetTransaction(transactionID);
        }

        public DateTime transactionDate {   get; set;  }
        //public string transacionByWho { get; set; }
        public string transactionLocation { get; set; }
        public double transactionAmount { get; set; }
        public bool debitOrCredit { get; set; }
        private double totalDebit { get; set; }
        private double totalCredit { get; set; }
        public double TotalPendingBalance { get; set; }
        public double CurrentBalance { get; set; }

        public bool NewTransaction(string byWho, string location, decimal amount,string debit, DateTime transactionDate,
            string transactionCleared, int? checkNumber, int transactionType)
        {
            Data.Transaction data = new Data.Transaction(ConfigurationManager.ConnectionStrings["CheckBook"].ToString());
            if (data.NewTransaction(byWho, location, amount, debit, transactionDate,transactionCleared,checkNumber,transactionType) > 0 )
                 return true;
            else
                return false;
        }

        public void GetCummlativeTotals()
        {
          
            Data.Transaction data = new Data.Transaction(ConfigurationManager.ConnectionStrings["CheckBook"].ToString());
            totalCredit = data.GetCummlativeCredits();
            totalDebit = data.GetCumlativeDebits();
            TotalPendingBalance = data.GetPendingBalances();
            CurrentBalance = totalCredit - totalDebit;
        }

        public void GetTransaction(int transactionID)
        {
            Data.Transaction data = new Data.Transaction(ConfigurationManager.ConnectionStrings["CheckBook"].ToString());
            DataTable dt = data.GetTransactionByTransactionID(transactionID);
            transactionDate = DateTime.Parse(dt.Rows[0]["TransactionOccured"].ToString());
            transactionLocation = dt.Rows[0]["Location"].ToString();
            transactionAmount = Double.Parse(dt.Rows[0]["Amount"].ToString());
        }

        public DataTable GetAllTransactions()
        {
            Data.Transaction data = new Data.Transaction(ConfigurationManager.ConnectionStrings["CheckBook"].ToString());
            DataTable dt = data.GetAllTransactions();
            DataTable newDt = new DataTable();
            newDt.Columns.Add("TransactionID", typeof(string));
            newDt.Columns.Add("TransactionOccured", typeof(string));
            newDt.Columns.Add("Amount", typeof(string));
            newDt.Columns.Add("TransactionCleared", typeof(bool));
            newDt.Columns.Add("Description", typeof(string));

            foreach (DataRow dr in dt.Rows)
            {
                DataRow newRow = newDt.NewRow();
                newRow["TransactionID"] = dr["TransactionID"];
                newRow["TransactionOccured"] = DateTime.Parse(dr["TransactionOccured"].ToString()).ToShortDateString();
                newRow["Amount"] = "$" + (dr["Amount"]);
                if (dr["TransactionCleared"].ToString() == "t")
                {
                    newRow["TransactionCleared"] = true;
                }
                else
                {
                    newRow["TransactionCleared"] = false;
                }
                newRow["Description"] = dr["Location"];
                newDt.Rows.Add(newRow);
            }
            return newDt;
        }

        
    }
}
