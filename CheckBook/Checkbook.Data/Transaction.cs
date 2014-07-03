using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.WebModules.Data;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace Checkbook.Data
{
    public class Transaction:DbObject
    {
        public Transaction (string connString):base(connString){}

        public int NewTransaction(string byWho, string location, decimal amount, string debit, DateTime transactionDate, string transactionCleared,
            int? checkNumber, int transactionType)
        {
            int rowsAffected;
            int transactionID;
            SqlParameter[] parameters = {
                                           //new SqlParameter("@byWho",SqlDbType.VarChar,50),
                                           new SqlParameter("@amount",SqlDbType.Decimal,18),
                                           new SqlParameter("@location",SqlDbType.VarChar,50),
                                           new SqlParameter("@transactionCleared",SqlDbType.VarChar,1),
                                           new SqlParameter("@debitOrCredit",SqlDbType.VarChar,6),
                                           new SqlParameter("@currentTime",SqlDbType.DateTime),
                                           new SqlParameter("@transactionType",SqlDbType.Int,5)
                                       };
            //parameters[0].Value = byWho;
            parameters[0].Value = amount;
            parameters[1].Value = location;
            parameters[2].Value = transactionCleared;
            parameters[3].Value = debit;
            parameters[4].Value = transactionDate;
            parameters[5].Value = transactionType;
            transactionID = RunProcedure("NewTransaction", parameters, out rowsAffected);

            //if transactiontype is check
            if (checkNumber != null)
            {
                if (rowsAffected > 0)
                {
                    int rowsAffected2;
                    SqlParameter[] parameters2 = {
                                                     new SqlParameter("@transactionID",SqlDbType.Int,5),
                                                     new SqlParameter("@checkNumber",SqlDbType.Int,5)
                                                 };
                    parameters2[0].Value = transactionID;
                    parameters2[1].Value = checkNumber;
                    RunProcedure("sp_Checks", parameters2, out rowsAffected2);
                    return rowsAffected2;
                }
            }
            return rowsAffected;
        }

        public double GetCummlativeCredits()
        {
            DataTable dt = RunProcedureNoParameters("sp_GetCumlativeCreditBalance").Tables[0];
            if (dt.Rows[0][0] != null)
                return Double.Parse(dt.Rows[0][0].ToString());
            else
                return 0;
            
        }

        public double GetCumlativeDebits()
        {
            return Double.Parse(RunProcedureNoParameters("sp_CumlativeDebitBalance").Tables[0].Rows[0]["TotalDebit"].ToString());
        }

        public double GetPendingBalances()
        {
            //return Double.Parse(RunProcedureNoParameters("sp_GetCumlativePendingBalance").Tables[0].Rows[0]["TotalPending"].ToString());
            DataTable dt = RunProcedureNoParameters("sp_CumlativePendingBalance").Tables[0];
            if (dt.Rows[0][0] != null)
                return Double.Parse(dt.Rows[0][0].ToString());
            else
                return 0;
        }
        public DataTable GetTransactionByTransactionID(int transactionID)
        {
            SqlParameter[] parameters = {new SqlParameter("@transactionID", SqlDbType.Int, 5)};

            parameters[0].Value = transactionID;
            return RunProcedure("sp_GetTransactionbyTransactionID", parameters, "Transaction").Tables[0];
        }

        public DataTable GetAllTransactions()
        {
            return RunProcedureNoParameters("sp_GetAllTransactions").Tables[0];
        }
   

    }
}
