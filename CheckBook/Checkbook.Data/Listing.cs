using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrox.WebModules.Data;
using System.Data;
using System.Data.SqlClient;

namespace Checkbook.Data
{
    public class Listing:DbObject
    {
        public Listing(string connectionString) : base(connectionString) { }
        public DataSet GetTransactionTypes()
        {
            //SqlParameter[] parameter = null;
            return RunProcedureNoParameters("sp_GetTransactionTypes");
        }
    }
}
