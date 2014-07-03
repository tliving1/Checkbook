using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Configuration;
using System.Data;

namespace Checkbook.Business
{
    public static class Listing
    {
        
        public static Hashtable AllTransactionTypes()
        {
            Hashtable ht = new Hashtable();
            Checkbook.Data.Listing listings = new Data.Listing(ConfigurationManager.ConnectionStrings["CheckBook"].ToString());
            DataTable dt = listings.GetTransactionTypes().Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                ht.Add(dr["TransactionTypeID"], dr["TransactionType"]);
            }

            return ht;
        }
    }
}
